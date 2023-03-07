using DbFinal.Models;
using DbFinal.ViewModels.HomeModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.Mvc;

namespace DbFinal.Controllers
{
    public class HomeController : Controller
    {

        // hata sayfası view i 
        public ActionResult ErrorPage()
        {
            return View();
        }
        #region  Yayınevi İşlemleri
        
        // Yayınevi listeleme fonksiyonu
        public ActionResult PublicationList()
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();

             var  model =  ent.usp_PublicationList().ToList();

            return View(model);
            // Yayınevi listeleme prosedürünü kulllanıyorum gelen sonucu listeye çevirerek view e gönderiyorum.
        }

        public ActionResult DeletePublication(int? id)
        {
            // View ekranından gelen id i alıyorum
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            var id1 = id.ToString();
           int sonuc=  ent.usp_DeletePublication(id1);
            // id yi stringe çevirerek prosedüre gönderiyorum sonucu int değere atıyorum
            if(sonuc == -1)
            {
                return RedirectToAction("ErrorPage");
            }
            //hata var mı diye kontrol ediyorum varsa hata sayfasına yönlendiriyorum

            return RedirectToAction("PublicationList");
            //yoksa view sayfasına gidiyor
        }

        public ActionResult CreatePublication()
        {
            // publication oluşturma viewi 
            return View();
        }

        [HttpPost]
        public ActionResult CreatePublication(Publication publication)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();

            //formdan gelen veriyi string değişkene atıyorum
            string str = publication.publicationName;
            ent.usp_ImportPublication(str);
            ent.SaveChanges();
            // değişkeni ekleme prosedürüne gönderiyorum
            return RedirectToAction("PublicationList");
        }




        public ActionResult EditPublication(int id)
        {

            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            //view sayfasından gelen id yi tek satır döndüren fonksiyona gönderiyorum
            // id ye karşılık gelen kayıtı listeye atıyorum
            var model = ent.usp_PublicationId(id).ToList();
           //listeyi edit sayfasına gönderiyorum
            return View(model);
        }

        [HttpPost]
        public ActionResult EditPublication(Publication publication)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();

            // edit sayfasındaki formdan gelen verileri string değişkenlere atıyorum
            string id = publication.publicationId.ToString();
            string str = publication.publicationName;
            ent.usp_UpdatePublication(id, str);
            ent.SaveChanges();

            //değişkenleri güncelleme prosedürüne gönderiyorum
            return RedirectToAction("PublicationList");
        }



        #endregion


        #region Yazar İşlemleri
        //yazar listeleme fonksiyonu
        public ActionResult AuthorList()
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            var model = ent.usp_AuthorList().ToList();
            return View(model);
            //Yazar listeleme prosedürünü kullanıyorum gelen sonucu listeye çeviriyorum sonucu view e gönderiyorum
        }

        public ActionResult DeleteAuthor(int? id)
        // Yazar silme fonksiyonu
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            Author model = new Author();

            string str = id.ToString();
           int sonuc=  ent.usp_DeleteAuthor(str);
            // listeleme sayfasından gelen id yi stringe çeviyorum ve ilgili prosedüre gönderiyorum 

            if (sonuc == -1)
            {
                return RedirectToAction("ErrorPage");
            }
            // Hata oluşması durumunda hata sayfasına gönderiyorum
            return RedirectToAction("AuthorList");
            //eğer hata oluşmazsa listeleme ekranına gönderiyorum
        }

        public ActionResult CreateAuthor()
        {
            // yazar oluşturma view i
            return View();
        }


        [HttpPost]
        public ActionResult CreateAuthor(Author author)
        {
            //view ekranından gelen değerleri tek tek string değişkenlere atıyorum
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();


            string str = author.authorName;
            string str1 = author.authorSurname;
            ent.usp_ImportAuthor(str, str1);
            ent.SaveChanges();
            //değişkennleri yazar ekleme prosedürüne gönderiyorum

            return RedirectToAction("AuthorList");
        }


        // Yazar düzenleme fonksiyonu
        public ActionResult EditAuthor(int id)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();

            var model = ent.usp_AuthorId(id).ToList();
            //Listeleme sayfasından gelen id yi alıyorum ve ilgili prosedüre gönderiyorum.
            //İd ye karşılık gelen kaydı ddöndüren prosedürünün sonucunu listeye çevirerek  yazar düzenleme viewine gönderiyorum
            return View(model);
        }

        //edit sayfasından gelen bilgileri alan fonksiyon

        [HttpPost]
        public ActionResult EditAuthor(Author author)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            //gelen bilgileri değişkenlere atıyorum
            string id = author.authorId.ToString();
            string str = author.authorName;
            string str1 = author.authorSurname;
            //değişkenleri yazar güncelleme prosedürüne gönderiyorum
            ent.usp_UpdateAuthor(id, str, str1);
            ent.SaveChanges();
            // yazar listeleme sayfasına gönderiyorum
            return RedirectToAction("AuthorList");
        }

        #endregion


        #region Kategori İşlemleri
        public ActionResult CategoryList()
        {
            // kategori listeleme fonksiyonu
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            var model = ent.usp_CategoryList().ToList();
            // kategori tablosunda bulunan kayıtları döndüren fonksiyonu kullanıyorum
            //sonuucunu listeye çevirip ilgili view e gönderiyorum
            return View(model);

        }

        public ActionResult DeleteCategory(int? id)
        {
            // Kategori listeleme sayfasından gelen id değerini alıyprum
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
       

            string str = id.ToString();
            int sonuc = ent.usp_DeleteCategory(str);
            // id yi stringe çevirip kategori silme prosedürüne gönderiyorum

            if (sonuc == -1)
            {
                return RedirectToAction("ErrorPage");
                //foreign key den dolayı hata oluşması durumunda hata sayfasına gönderiyorum
            }
            // hata oluşmazsa kategori listeleme sayfasına gönderiyorum
            return RedirectToAction("CategoryList");
        }



        // Kategori oluşturma view i 
        public ActionResult CreateCategory()
        {
            return View();
        }

        // Kategori oluşturma sayfasından gelen değerleri alıyorum

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            //gelen isim değerini değişene atıyorum

            string str = category.categoryName;
            ent.usp_ImportCategory(str);
            ent.SaveChanges();
            //değişkeni kategori ekleme prosedürüne gönderiyorum ardından kategori listeleme sayfasına gönderiyorum
            return RedirectToAction("CategoryList");
        }


        // kategori düzenleme fonksiyonu
        public ActionResult EditCategory(int id)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            //Listeleme  sayfasından gelen id değerini, id ye göre kayıt döndüren fonksiyona gönderiyorum ve sonucu listeye çeviriyorum
            var model = ent.usp_CategoryId(id).ToList();
            // listeyi ilgili view e gönderiyorum
            return View(model);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            //düzenleme sayfasından gelen değerleri alarak değişkenlere atıyorum
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();

            string id = category.categoryId.ToString();
            string str = category.categoryName;
            ent.usp_UpdateCategory(id, str);
            ent.SaveChanges();
            //değişkenleri kategori düzenleme prosedürüne gönderiyorum ve ardından kategori listelem sayfasına gönderiyorum

            return RedirectToAction("CategoryList");
        }



        #endregion


        #region Kitap İşlemleri

        //kitap listeleme fonksiyonu
        public ActionResult BookList()
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            var model = ent.usp_Book().ToList();
            // Book tablosunu döndüren fonksiyonu kullanarak sonucu listeye atıyorum
            //listeyi ilgili view e gönderiyorum
            return View(model);

        }
        // kitap silme fonksiyonu
        public ActionResult DeleteBook(int? id)
        {
            //listeleme sayfasından gelen id yi alıyorum 
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            string str = id.ToString();
            // id i stringe çevirerek kitap silme prosedürüne gönderiyorum
           int sonuc =  ent.usp_DeleteBook(str);
            if (sonuc == -1)
            {
                // silme işleminde hata oluşursa hata sayfasına gönderiyorum
                return RedirectToAction("ErrorPage");
            }
            // hata oluşmazsa kitap listeleme sayfasına gönderiyorum
            return RedirectToAction("BookList");
        }


        public ActionResult CreateBook()
        {
            // Kitap oluşturma fonksiyonu
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            // yazar listelemek için kullandığım fonksiyonu kullandım sonucu listeye çevirdim
            var  authorList = ent.usp_AuthorList().ToList();
            //listeyi ilgili view e gönderdim
            return View(authorList);

            // burada yazar listesini göndermeyebilirdim
            // yazar, kategori, yayınevi listeleri kitap eklemek için gerekli olduğu dropdown şeklinde çektirmek için listeleri kullandım
            // diğer listeleri ilgili view sayfasında çekerek kullandım
        }


        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            // kitap oluşturma sayfasından gelen değerleri değişkenlere atadım

            string str = book.bookName;
            string id = book.categoryId.ToString();
            string id1 = book.publicationId.ToString();
            string id2 = book.authorId.ToString();
            ent.usp_ImportBook(str,id,id1,id2);
            //değişkenleri kitap ekleme prosedürüne gönderdim

            //işlem sonucunda kitap listeleme sayfasına gönderdim
            return RedirectToAction("BookList");
        }


        //kitap düzenleme fonksiyonu
        public ActionResult EditBook(int id)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            // listeleme sayfasından gelen id bilgisini id ye kayıt döndüren fonksiyona gönderdim ve sonucu listeleye çevirdim
            var model = ent.usp_BookId(id).ToList();
            //listeyi ilgili view e gönderdim
            return View(model);
        }


        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            //kitap düzenleme sayfasından gelen bilgileri değişkenlere atadım
            string id = book.bookId.ToString();
            string str = book.bookName;
            string str1 = book.categoryId.ToString();
            string str2 = book.publicationId.ToString();
            string str3 = book.authorId.ToString();

            ent.usp_UpdateBook(id, str, str1,str2,str3);
            //değişkenleri kitap düzenleme prosedürüne gönderdim
            ent.SaveChanges();
            // ardından kitap listeleme sayfasına gönderdim
            return RedirectToAction("BookList");
        }

            #endregion
            
            //üye listeleme fonksiyonu
            #region Üye İşlemleri
            public ActionResult MemberList()
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            var model = ent.usp_MemberList().ToList();
            // Member tablosundaki kayıtları döndüren fonksiyonu kullandım ve sonucu listeye çevirdim
            //listeyi ilgili view e gönderdim
            return View(model);

        }
        //üye silme fonksiyonu
        public ActionResult DeleteMember(int? id)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();

            string str = id.ToString();
            //listeleme sayfasından gelen id yi string e çevirerek üye silme prosedürüne gönderiyorum
            int sonuc = ent.usp_DeleteMember(str);
            if (sonuc == -1)
            {
                //hata oluşması duruununda hata sayfasına gönderiyorum
                return RedirectToAction("ErrorPage");
            }
            //hata oluşmazsa üye listeleme sayfasına gönderiyorum

            return RedirectToAction("MemberList");
        }
        //üye oluşturma view i
        public ActionResult CreateMember()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateMember(Member member)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();

            //üye oluşturma sayfasından gelen bilgileri değişkenlere atıyorum
            string str = member.memberName;
            string str1 = member.memberSurname;
            ent.usp_ImportMember(str, str1);
            //değişkenleri üye ekleme prosedürüne gönderiyorum
            ent.SaveChanges();
            // işlemin ardından üye listeleme sayfasına gönderiyorum
            return RedirectToAction("MemberList");
        }


        //üye düzenleme fonksiyonu
        public ActionResult EditMember(int id)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();

            var model = ent.usp_MemberId(id).ToList();
            //üye listeleme sayfasından gelen id bilgisini id ye göre kayıt döndüren fonksiyona gönderiyorum

            return View(model);
        }
        
        [HttpPost]
        public ActionResult EditMember(Member member)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            // üye düzenleme sayfasından gelen değerleri değişkenlere atıyorum
            string id = member.memberId.ToString();
            string str = member.memberName;
            string str1 = member.memberSurname;
            ent.usp_UpdateMember(id, str, str1);
            ent.SaveChanges();
            //değişkenleri üye düzenleme prosedürüne gönderiyorum
            //işlemin ardından üye listeleme sayfasına gönderiyorum
            return RedirectToAction("MemberList");
        }

        #endregion

        // ödünç verme listeleme fonksiyonu
        #region Ödünç Verme İşlemleri
        public ActionResult LendList()
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
           //lend tablosundaki değerleri döndüren fonksiyonu kullanyorum sonucu listeye çeviriyorum
           //listeyi ilgili view e gönderiyorum

            var model = ent.usp_Lend().ToList();
            return View(model);

        }
        // lend silme fonksiyonu
        public ActionResult DeleteLend(int? id)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            // listeleme sayfaısndan gelen id değerini string e çevirip lend silme prosedürüne gönderiyorum
            string str = id.ToString();
            int sonuc = ent.usp_DeleteLend(str);
            if (sonuc == -1)
            {
                // hata oluşması durumunda hata sayfasına gönderiyorum
                return RedirectToAction("ErrorPage");
            }
            return RedirectToAction("LendList");
        }// hata oluşmazsa lend listeleme sayfasına gönderiyorum

        // lend oluşturma view i 
        public ActionResult CreateLend()
        {
            return View();
        }

        // lend oluşturma fonksiyonu
        [HttpPost]
        public ActionResult CreateLend(Lend lend)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();

            // lend oluşturma sayfasındand gelen değerleri değişkene atıyorum
            string str = lend.bookId.ToString();
            string str1 = lend.memberId.ToString();
            string str2 = lend.lendTime.ToShortDateString();
            string str3 = lend.lendLength.ToString();
            ent.usp_ImportLend(str2, str3,str1,str);
            //değişkenleri lend ekleme prosedürüne gönderiyorum
            //işlemlerin ardınadn lend listeleme sayfasına gönderiyorum
            return RedirectToAction("LendList");
        }


        //lend düzenleme 
        public ActionResult EditLend(int id)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            // lend listeleme sayfasından gelen id yi , id ye göre kayıt döndüren fonksiyona gönderiyorum
            //sonucu listeye çeviyorum
            var model = ent.usp_LendId(id).ToList();
            //listeyi ilgili view e gönderiyorum
            return View(model);
        }

        [HttpPost]
        public ActionResult EditLend(Lend lend)
        {
            // lend düzenleme sayfasından gelen bilgileri değişkenlere atıyorum
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            string id1 = lend.lendId.ToString();
            string id = lend.memberId.ToString();
            string id2 = lend.bookId.ToString();
            string str = lend.lendTime.ToShortDateString();
            string str1 = lend.lendLength.ToString();

            //değişkenleri lend düzenleme prosedürüne gönderiyorum
            ent.usp_UpdateLend(id1, str, str1, id ,id2 );
            ent.SaveChanges();

            //işlemin ardından lend listeleme sayfasına gönderiyorum
            return RedirectToAction("LendList");
        }


        #endregion

        #region Admin İşlemleri

        //admin listeleme fonksiyonu
        public ActionResult AdminList()
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            // admin listesindeki kayıtları döndüren prosedürü kullandım sonucu listeye çevirdim
            var model = ent.usp_AdministratorList().ToList();
            //listeyi ilgili viewe gönderdim
            return View(model);

        }
        //admin silme fonksiyonu
        public ActionResult DeleteAdmin(int? id)
        {
            //admin listeleme sayfasından gelen değeri alıp string değişkene atadım
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            var id1 = id.ToString();
            //değişkeni admin silme prosedürüne gönderdim
            int sonuc = ent.usp_DeleteAdministrator(id1);
            if (sonuc == -1)
            {
                return RedirectToAction("ErrorPage");
                //hata oluşması durunununda hata sayfasına gönderdim
            }
            return RedirectToAction("AdminList");
        }//hata oluşmazsa admin listeleme sayfasına gönderdim

        //admin oluşturma view i 
        public ActionResult CreateAdmin()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateAdmin(Administrator administrator)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            //admin oluşturma sayfasından gelen bilgileri değişkenlere atadım

            string str = administrator.administratorName;
            string str1 = administrator.administratorSurname;
            string str2 = administrator.administratorSurname;
            string str3 = administrator.administratorPassword;
            //değişkenleri admin ekleme prosedürüne gönderdim
            ent.usp_ImportAdministrator(str,str1,str2,str3);
            ent.SaveChanges();
            //işlemlerin ardından admin listelme sayfasına gönderdim
            return RedirectToAction("AdminList");
        }



        //admin düzenleme fonksiyonu
        public ActionResult EditAdmin(int id)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            //listeleme sayfasından gelen id yi aldım
            //id ye göre kayıt döndüren fonksiyonu kullandım soncu listeye çevirdim
            var model = ent.usp_AdministratorId(id).ToList();
            //listeyi ilgili view e gönderdim
            return View(model);
        }

        [HttpPost]
        public ActionResult EditAdmin(Administrator administrator)
        {
            LibrayDatabaseEntities ent = new LibrayDatabaseEntities();
            // admin düzenleme sayfasından gelen bilgileri değişkenlere atadım
            string id = administrator.administratorId.ToString();
            string str = administrator.administratorName;
            string str1 = administrator.administratorSurname;
            string str2 = administrator.administratorUsername;
            string str3 = administrator.administratorPassword;
            //değişkenleri admin düzenleme prosedürüne gönderdim
            ent.usp_UpdateAdministrator(id, str,str1,str2,str3);
            ent.SaveChanges();
            // işlemlerin ardından admin listeleme sayfasına gönderdim
            return RedirectToAction("AdminList");
        }



        #endregion
    }
}
