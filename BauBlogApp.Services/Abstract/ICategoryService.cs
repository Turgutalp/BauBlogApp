using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BauBlogApp.Entities.Concrete;
using BauBlogApp.Entities.Dtos;
using BauBlogApp.Shared.Utilities.Results.Abstract;

namespace BauBlogApp.Services.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<Category>> Get(int categoryId);
        Task<IDataResult<IList<Category>>> GetAll();
        //Kategori eklemek istedik.
        Task<IResult> Add(CategoryAddDto categoryAddDto, string createdbyName);
        Task<IResult> Update(CategoryUpdateDto categoryUpdateDto, string modifiedByName);
        Task<IResult> Delete(int categoryId); // silinmis gibi gorunur
        Task<IResult> HardDelete(int categoryId); // veri tabanindan silinir
        
        
        


    }
}