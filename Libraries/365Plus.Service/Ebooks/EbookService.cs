using _365Plus.Core.Data;
using _365Plus.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Plus.Service.Ebooks
{
    public class EbookService
    {
        private readonly IRepository<Data.Models.Ebook> _ebookRepository;
        private readonly IRepository<Data.Models.UserSubscriptionStatu> _userSubscriptionStatuRepository;

        public EbookService(IRepository<Data.Models.Ebook> ebookRepository, IRepository<Data.Models.UserSubscriptionStatu> userSubscriptionStatuRepository)
        {
            this._ebookRepository = ebookRepository;
            this._userSubscriptionStatuRepository = userSubscriptionStatuRepository;
        }

        public List<EbookModel> GetAllEbooks()
        {
            var data = from a in this._ebookRepository.Table
                       select new EbookModel
                       {
                           Id = a.Id,
                           Title = a.Title,
                           Description = a.Description,
                           Price = a.Price
                       };
            return data.ToList();
        }
        public List<EbookModel> GetAllEbooksForClient(int userId)
        {
            var data = from a in this._userSubscriptionStatuRepository.Table
                       where a.UserId == userId && a.IsActive == true
                       select new EbookModel
                       {
                           Id = a.Ebook.Id,
                           Title = a.Ebook.Title,
                           Description = a.Ebook.Description,
                           Price = a.Ebook.Price
                       };
            return data.ToList();
        }
        public EbookModel GetEbooksByID(double id)
        {
            var data = from a in this._ebookRepository.Table
                       where a.Id == id
                       select new EbookModel
                       {
                           Id = a.Id,
                           Title = a.Title,
                           Description = a.Description,
                           Price = a.Price
                       };

            return data.FirstOrDefault();
        }

        public Data.Models.Ebook AddEbook(Data.Models.Ebook ebook)
        {

            this._ebookRepository.Insert(ebook);
            return ebook;
        }

        public void UpdateEbook(EbookModel ebook)
        {

            var existingEbook = _ebookRepository.Table.FirstOrDefault(f => f.Id == ebook.Id);
            if (existingEbook != null)
            {
                //Update
                existingEbook.Title = ebook.Title;
                existingEbook.Description = ebook.Description;
                existingEbook.Price = ebook.Price;

                _ebookRepository.Update(existingEbook);
            }

        }
    }
}
