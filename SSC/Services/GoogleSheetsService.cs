using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace SSC.Services;

    public class GoogleSheetsService
    {
        private SheetsService service;
        private string ApplicationName = "MyAttendanceApp";

        public GoogleSheetsService()
        {
            InitializeServise();
        }

        private void InitializeServise()
        {
            string[] Scopes = { SheetsService.Scope.Spreadsheets };
            GoogleCredential credential;
            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            { 
                credential = GoogleCredential.FromStream(stream).CreateScoped(Scopes);
            }

            service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public bool UpdateOneTimeCode(string spreadsheetId, string newCode)
        {
            try
            {
                string range = "Codes!A2";
                var valueRange = new ValueRange();
                var oblist = new List<object>() { newCode };
                valueRange.Values = new List<IList<object>> { oblist };

                var updateRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
                updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                updateRequest.Execute();
                return true;
            }
            catch (Exception ex)
            { 
                return false;
            }
        }

        public bool ValidateOneTimeCode(string spreadsheetId, string inputCode)
        {
            try
            {
                string range = "Codes!A2";
                var request = service.Spreadsheets.Values.Get(spreadsheetId, range);
                var response = request.Execute();
                var values = response.Values;
                if (values != null && values.Count > 0)
                {
                    var storedCode = values[0][0].ToString();
                    if (storedCode == inputCode)
                    {
                        var valueRange = new ValueRange();
                        var oblist = new List<object>() { "" };
                        valueRange.Values = new List<IList<object>> { oblist };
                        var updateRequest = service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
                        updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
                        updateRequest.Execute();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            { 
                return false; 
            }
        }

        public bool LogScanData(string spreadsheetId, string token, string userId, double? lat, double? lng)
        {
            try
            {
                string range = "Log!A:E";
                var valueRange = new ValueRange();
                var currentTime = DateTime.Now.ToString("g");
                var oblist = new List<object>()
                {
                    token,
                    userId,
                    lat.HasValue ? lat.Value.ToString() : "",
                    lng.HasValue ? lng.Value.ToString() : "",
                    currentTime
                };
                valueRange.Values = new List<IList<object>> { oblist };

                var appendRequest = service.Spreadsheets.Values.Append(valueRange, spreadsheetId, range);
                appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
                appendRequest.InsertDataOption = SpreadsheetsResource.ValuesResource.AppendRequest.InsertDataOptionEnum.INSERTROWS;
                appendRequest.Execute();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }


