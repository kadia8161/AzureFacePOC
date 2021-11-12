using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using System.IO;
using System.Threading.Tasks;
using System.Data;

namespace AzureFacePOC
{
    public partial class Form1 : Form
    {
        const string FACE_SUBSCRIPTION_KEY = "Azure_Face_Api_Key";
        const string FACE_ENDPOINT = "Azure_Face_Api_Endpoint";
        const string RECOGNITION_MODEL4 = RecognitionModel.Recognition04;
        const string DETECTION_MODEL3 = DetectionModel.Detection03;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private readonly IFaceClient _faceClient;
        const string LP_GROUP_ID = "largepersongroup01";
        const string LP_GROUP_NAME = "LargePersonGroup";
        public Form1()
        {
            InitializeComponent();
            _faceClient = new FaceClient(new ApiKeyServiceClientCredentials(FACE_SUBSCRIPTION_KEY)) { Endpoint = FACE_ENDPOINT };
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.FileOk += OpenFileDialog1_FileOk;
            openFileDialog2 = new OpenFileDialog();
            openFileDialog2.FileOk += OpenFileDialog2_FileOk;
            //FaceDetection.Initialize(FACE_ENDPOINT, FACE_SUBSCRIPTION_KEY, DETECTION_MODEL3);
            BindPersonList();
        }
        private void BindPersonList()
        {
            IList<Person> persons = GetPersonList();
            DataTable dtPerson = new DataTable();
            dtPerson.Columns.Add("Person Id", typeof(string));
            dtPerson.Columns.Add("Name", typeof(string));
            dtPerson.Columns.Add("Customer Id", typeof(string));
            dtPerson.Columns.Add("Face ID", typeof(string));
            dtPerson.Columns.Add("Face Details", typeof(string));
            DataRow dr;
            foreach (var per in persons)
            {
                dr = dtPerson.NewRow();
                dr["Person Id"] = per.PersonId.ToString();
                dr["Name"] = per.Name;
                dr["Customer Id"] = per.UserData;
                dr["Face ID"] = per.PersistedFaceIds[0]; //string.Join(",", per.PersistedFaceIds);
                dr["Face Details"] = GetPersonFaceDetails(LP_GROUP_ID, per.PersonId, per.PersistedFaceIds[0]);
                dtPerson.Rows.Add(dr);
                if (per.PersistedFaceIds.Count > 1)
                {
                    for (int i = 1; i < per.PersistedFaceIds.Count; i++)
                    {
                        dr = dtPerson.NewRow();
                        dr["Face ID"] = per.PersistedFaceIds[i];
                        dr["Face Details"] = GetPersonFaceDetails(LP_GROUP_ID, per.PersonId, per.PersistedFaceIds[i]);
                        dtPerson.Rows.Add(dr);
                    }
                }
            }
            personList.DataSource = dtPerson;
        }

        private string GetPersonFaceDetails(string largePersonGroupId, Guid personId, Guid faceId)
        {
            PersistedFace persistedFace = _faceClient.LargePersonGroupPerson.GetFaceAsync(largePersonGroupId, personId, faceId).GetAwaiter().GetResult();
            return persistedFace.UserData;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            lblResultProcess.Text = "Loading...";
            //Image image_Photo = Image.FromFile(txtImage.Text);
            //Image image_ID = Image.FromFile(txtID.Text);
            string imageFaceId;
            using (FileStream fileStream = File.OpenRead(txtWebCamImage.Text))
            {
                imageFaceId = GetFaceId(_faceClient, fileStream);
            }
            //string imageFaceId = GetFaceId(_faceClient, image_Photo);
            //string icardFaceId = GetFaceId(_faceClient, image_ID);
            lblResultProcess.Text = "Completed";
            txtCompareResult.Text = ComparaFace(_faceClient, imageFaceId);
        }

        private string GetFaceId(IFaceClient faceClient, Stream imageStream)
        {
            try
            {
                string faceId = null;
                if (faceClient != null)
                {
                    IList<DetectedFace> detectedFaces = faceClient.Face.DetectWithStreamAsync(image: imageStream, returnFaceId: true, faceIdTimeToLive: 300, detectionModel: DETECTION_MODEL3,
                        recognitionModel: RECOGNITION_MODEL4).Result;
                    if (detectedFaces.Count > 0)
                    {
                        faceId = detectedFaces[0].FaceId.Value.ToString();
                    }
                }
                return faceId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string ComparaFace(IFaceClient faceClient, string imageGuid)
        {
            try
            {
                //List<Guid?> compareGuids = new List<Guid?>();
                //compareGuids.Add(Guid.Parse(idGuid));

                IList<IdentifyResult> similarFaces = faceClient.Face.IdentifyAsync(new List<Guid>() { Guid.Parse(imageGuid) },
                    null, LP_GROUP_ID, 5, 0.5d).GetAwaiter().GetResult();
                //Face.FindSimilarAsync(Guid.Parse(imageGuid), 
                // null, null, compareGuids, 10, FindSimilarMatchMode.MatchFace).Result;
                //VerifyResult result = faceClient.Face.VerifyFaceToFaceAsync(Guid.Parse(imageGuid), Guid.Parse(idGuid)).GetAwaiter().GetResult();
                //return "Confidence " + result.Confidence.ToString("#0.#####") + " IsIdentical : " + (result.IsIdentical ? "Yes" : "No");
                if (similarFaces.Any())
                {
                    StringBuilder sbResult = new StringBuilder();
                    sbResult.AppendLine("Find Following Customers");
                    Person matchedPerson;
                    foreach (var candidate in similarFaces[0].Candidates)
                    {
                        matchedPerson = GetPerson(LP_GROUP_ID, candidate.PersonId);
                        sbResult.AppendLine($"Name : {matchedPerson.Name} CustomerId : {matchedPerson.UserData} Confidence : {candidate.Confidence.ToString("#0.#####")}");
                    }
                    return sbResult.ToString();
                }
                else
                {
                    return "No Match Found";
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Person GetPerson(string largePersonGroupId, Guid personId)
        {
            return _faceClient.LargePersonGroupPerson.GetAsync(largePersonGroupId, personId).GetAwaiter().GetResult();
        }

        private void btnImageSelect_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtImage.Text = ((FileDialog)sender).FileName;
        }

        private void btnBrowseCamImage_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void OpenFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            txtWebCamImage.Text = ((FileDialog)sender).FileName;
        }

        private void btnAddFace_Click(object sender, EventArgs e)
        {

            lblFaceAddProcess.Text = "Processing...";
            using (Stream image = File.OpenRead(txtImage.Text))
            {
                AddFaceToPersonGroup(image, txtCustomerId.Text.Trim(), txtPersonId.Text.Trim(), txtFaceCustomData.Text.Trim());
            }
            BindPersonList();
        }

        private void AddFaceToPersonGroup(Stream image, string customerId, string personId, string faceCustomData)
        {
            try
            {
                bool groupExists = CheckLargePersonGroupExists(LP_GROUP_ID);
                if (!groupExists)
                {
                    lblFaceAddProcess.Text = "Creating Person Group...";
                    CreateLargePersonGroup(LP_GROUP_ID, LP_GROUP_NAME, "Store Person Data");
                }
                Guid personGuid = new Guid();
                if (string.IsNullOrWhiteSpace(personId))
                {
                    lblFaceAddProcess.Text = "Creating Person...";
                    personGuid = CreateLargePersonGroupPerson(LP_GROUP_ID, txtCustomerName.Text, customerId);
                }
                else
                {
                    personGuid = Guid.Parse(personId);
                }
                lblFaceAddProcess.Text = "Adding Face For Person...";
                Guid personFaceId = AddFaceToLargePersonGroupFromStream(LP_GROUP_ID, personGuid, image, faceCustomData);
                MessageBox.Show($"Face with FaceId : {personFaceId} Added For PersonId : {personGuid} Under Person Group : {LP_GROUP_ID}");
                lblFaceAddProcess.Text = "Completed";
                ClearControl();
                BindPersonList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            _faceClient.Dispose();
        }
        private void ClearControl()
        {
            txtImage.Text = "";
            txtWebCamImage.Text = "";
            txtCustomerId.Text = "";
            txtPersonId.Text = "";
            txtCustomerName.Text = "";
            txtFaceCustomData.Text = "";
            //lblMatch.Text = "Confidence 0.0";
        }

        public void CreateLargePersonGroup(string largePersonGroupId, string largePersonGroupName, string customData)
        {
            _faceClient.LargePersonGroup.CreateAsync(largePersonGroupId, largePersonGroupName, customData, RECOGNITION_MODEL4).GetAwaiter().GetResult();
        }
        public Guid CreateLargePersonGroupPerson(string largePersonGroupId, string personName, string customData)
        {
            Person person = _faceClient.LargePersonGroupPerson.CreateAsync(largePersonGroupId, personName, customData).GetAwaiter().GetResult();
            return person.PersonId;
        }
        public Guid AddFaceToLargePersonGroupFromStream(string largePersonGroupId, Guid personId, Stream personImage,
            string customData = null, IList<int> faceRectangle = null)
        {
            PersistedFace persistedFace = _faceClient.LargePersonGroupPerson
                .AddFaceFromStreamAsync(largePersonGroupId, personId, personImage, customData,
                faceRectangle, DETECTION_MODEL3).GetAwaiter().GetResult();
            return persistedFace.PersistedFaceId;
        }
        public bool CheckLargePersonGroupExists(string largePersonGroupId)
        {
            try
            {
                LargePersonGroup largePersonGroup = _faceClient.LargePersonGroup.GetAsync(largePersonGroupId).GetAwaiter().GetResult();
                return largePersonGroup != null;
            }
            catch
            {
                return false;
            }
        }

        public IList<Person> GetPersonList()
        {
            return _faceClient.LargePersonGroupPerson.ListAsync(LP_GROUP_ID, null, 10).GetAwaiter().GetResult();
        }

        private void btnTrainPersonGroup_Click(object sender, EventArgs e)
        {
            lblFaceAddProcess.Text = "Train Person Group Started";
            TrainPersonGroup(LP_GROUP_ID);
            lblFaceAddProcess.Text = "Train Person Group Completed";
        }

        private void TrainPersonGroup(string largePersonGroupId)
        {
            Task trainTask = _faceClient.LargePersonGroup.TrainAsync(largePersonGroupId);
            do
            {
                Task.Delay(1000);
            }
            while (!trainTask.IsCompleted);
        }
    }
}
