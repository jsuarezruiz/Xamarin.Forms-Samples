namespace FormulaOneApp.Services.Storage
{
    public interface IStorageService
    {       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        string GetValueOrDefault(string key, string defaultValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddOrUpdateValue(string key, string value);
    }
}
