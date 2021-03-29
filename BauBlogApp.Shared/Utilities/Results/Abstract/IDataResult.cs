namespace BauBlogApp.Shared.Utilities.Results.Abstract
{
    public interface IDataResult <out T> : IResult
    {
        public T Data { get; }  // new DataResult<Category>(ResultStatus.Success,category);
                               // new DataResult<IList<Category>>(Resultstatus.Success,categoryList);
        
                               



    }
}