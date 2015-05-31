namespace FormulaOneApp.Services.Dialog
{
    using System.Threading.Tasks;

    public interface IDialogService
    {    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        Task Show(string content);
    }
}
