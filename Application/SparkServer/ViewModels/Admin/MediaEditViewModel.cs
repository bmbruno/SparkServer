using SparkServer.Application.Enum;
using System.Web;

namespace SparkServer.ViewModels
{
    public class MediaEditViewModel : BaseViewModel
    {
        public EditMode Mode { get; set; }
        
        public HttpPostedFileBase NewFile { get; set; }

        public MediaEditViewModel() { }
    }
}