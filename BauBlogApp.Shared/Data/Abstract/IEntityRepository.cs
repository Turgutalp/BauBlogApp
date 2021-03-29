using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BauBlogApp.Shared.Entities.Abstract;

namespace BauBlogApp.Shared.Data.Abstract
{
    
    // interface'e filtre ekliyoruz where T:class => referans tip olmali(class mesela), IEntity olmali ve veritabani nesnelerim new-lenebilir olmali.
    
    public interface IEntityRepository<T> where T:class, IEntity,new() //yalnizca veri tabani nesneleri gelebilir.

    {
    /*
     * Expression<Func<T,bool>> predicate
     * ID"si 7 olan makaleyi getirmek istiyoruz:
     * var makale = repository.Get(m=>m.Id==15);
     * Id'si 1 olan kullaniciyi getirmek istiyoruz;
     *  var kullanici = Get(k=>j.Id==1);
     * Adi "Turgut" olan kullaniciyi getirmek istiyoruz;
     * var kullanici = Get(k=>k.FirsrtName=="Turgut");
     * bizim verecegemiz lambda expressionlar predicate(filtre)'dir
     */

    //Asenkron
    //GetAsync=> Get Metodumuz
    //Expression=>Lambda.
    //predicate=>Filtre
    
    /*
     * Asenkron programlama prensiplerini kullandik..Neden ?
     * Asenkron programlama, tasklari parcalara ayirir ve tum islemlerin ayni anda surdurulmesini saglar.
     * Asenkron yaklasimda yazdigimiz bir kod parcasi calisirken, diger kod parcalarimiz da calisabilir
     * Bu sayede kullanici uygulamanin bir bolumunu kullanirken baska bir bolumu ile de islem yapabilir.
     * Uygulamamiza multitasking ozelligi ekler diyebiliriz.
     * Asenkron programlama , multi threading ile karistirilmamalidir.Asenkron olarak yazdigimiz kodlar
     * tek bir thread uzerinde calisabilir.Asenkron yaklasimmin ozelligi farkli threadler'de calismasi degil,
     * tasklari parcalara ayirarak uygulamada birden fazla isin ayni anda yurutulmesidir.
     */
    
    
    //Burada tum DAL claslar icin kullanabilecegimiz metodlari ekledik.
    
    
    Task<T> GetAsync(Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includeProperties);
    // var kullanici = repository.getAsync(k=>k.id==15)
    //*********************************

    //iki veya daha fazla entity icin;

    //Tum kategorileri getirmek istiyoruz,bunun icin bir lisyeye ihtiyacimiz var.
    //predicate = null; cunku: biz makalelerin hepsini de yuklemek isteyebilir, ya da kategoriye gore
    //yukleme yapmak isteyebiliriz.null gelsin ki hepsi yuklensin biz kategori bazli istersek predicate yollariz.
    Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
        params Expression<Func<T, object>>[] includeProperties);

    //T tipinde bir entity bekliyoruz.
    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(T entity);

    // bir entity eklerken daha once bu entity kullanilmis mi ? mesela bir email adresi ile baska kullanici kayit olmus mu ?
    //predicate = neye gore soruyosun ? mesela e-mail
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

    // admin panelinde elimizdeki verileri listelemek icin mesela kac makale var ? kac kullanici var ?
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);




    }
}