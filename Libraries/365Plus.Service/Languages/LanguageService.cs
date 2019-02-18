using _365Plus.Core.Data;
using _365Plus.Data.Models;
using _365Plus.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Plus.Service.Languages
{
    public class LanguageService
    {
        private readonly IRepository<Data.Models.Language> _languageRepository;

        public LanguageService(IRepository<Data.Models.Language> languageRepository)
        {
            this._languageRepository = languageRepository;
        }

        public List<LanguageModel> GetAll()
        {
            var data = from a in this._languageRepository.Table
                       select new LanguageModel
                       {
                           Id = a.Id,
                           Name = a.Name,
                           Culture = a.Culture,
                           IsActive = a.IsActive
                       };
            return data.ToList();
        }

        public LanguageModel GetLanguageById(double id)
        {
            var data = from a in this._languageRepository.Table
                       where a.Id==id
                       select new LanguageModel
                       {
                           Id = a.Id,
                           Name = a.Name,
                           Culture = a.Culture,
                           IsActive = a.IsActive
                       };
            return data.FirstOrDefault();
        }

        public Data.Models.Language AddLanguage(Data.Models.Language language)
        {
            this._languageRepository.Insert(language);
            return language;
        }

        public void UpdateLanguage(Language language)
        {
            var existingLanguage = _languageRepository.Table.FirstOrDefault(f => f.Id == language.Id);
            if (existingLanguage != null)
            {
                //Update
                existingLanguage.Name = language.Name;
                existingLanguage.Culture = language.Culture;
                existingLanguage.IsActive = language.IsActive;

                _languageRepository.Update(existingLanguage);
            }
        }
    }
}
