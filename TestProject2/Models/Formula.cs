
using Newtonsoft.Json;

namespace APITestAutomation.Models
{
   
    public class Formula
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("formulaID")]
        public string FormulaID { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("versionName")]
        public string VersionName { get; set; }

        [JsonProperty("approvalStatus")]
        public string ApprovalStatus { get; set; }

        [JsonProperty("formulaType")]
        public string FormulaType { get; set; }

        [JsonProperty("formulaActiveStatus")]
        public string FormulaActiveStatus { get; set; }

        [JsonProperty("updatedBy")]
        public string UpdatedBy { get; set; }

        [JsonProperty("updatedDate")]
        public string UpdatedDate { get; set; }

        [JsonProperty("approvedBy")]
        public string ApprovedBy { get; set; }

        [JsonProperty("approvedDate")]
        public string ApprovedDate { get; set; }

        [JsonProperty("attributes")]
        public object Attributes { get; set; } // Use appropriate type if known

        [JsonProperty("recipes")]
        public object Recipes { get; set; } // Use appropriate type if known

        [JsonProperty("apiUrl")]
        public string ApiUrl { get; set; }

        [JsonProperty("computeMethod")]
        public string ComputeMethod { get; set; }
    }

}
