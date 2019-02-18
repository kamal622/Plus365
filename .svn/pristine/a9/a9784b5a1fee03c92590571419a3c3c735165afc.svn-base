using _365Plus.Core.Data;
using _365Plus.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Plus.Service.Assistant
{
    public class AssistantService
    {
        private readonly IRepository<Data.Models.UserProfile> _userProfileRepository;
        private readonly IRepository<Data.Models.User> _userRepository;

        public AssistantService(IRepository<Data.Models.UserProfile> userProfileRepository, IRepository<Data.Models.User> userRepository)
        {
            this._userProfileRepository = userProfileRepository;
            this._userRepository = userRepository;

        }

        public void UpdateAssistant(AssistantModel assistant)
        {
           
                var existingAssistant = _userProfileRepository.Table.FirstOrDefault(f => f.Id == assistant.Id);
                if (existingAssistant != null)
                {
                    //Update
                    existingAssistant.FirstName = assistant.FirstName;
                    existingAssistant.LastName = assistant.LastName;
                    existingAssistant.PersonalEmail = assistant.PersonalEmail;
                   
                    existingAssistant.MobileNo = assistant.MobileNo;
                    existingAssistant.DateOfBirth = assistant.DateOfBirth;
                    
                    existingAssistant.UserCode = assistant.UserCode;
                    existingAssistant.CountryId = assistant.CountryId;
                    existingAssistant.LanguageId = assistant.LanguageId;
                   
                    existingAssistant.ModifiedBy = assistant.ModifiedBy;
                    existingAssistant.ModifiedDate = DateTime.UtcNow;
                    if (existingAssistant.CreatedBy == null)
                    {
                        existingAssistant.CreatedBy = assistant.ModifiedBy;
                        existingAssistant.CreatedDate = DateTime.UtcNow;

                    }
                    _userProfileRepository.Update(existingAssistant);

                }
                
        }

        public List<AssistantModel> GetAll()
        {
            var data = from a in this._userRepository.Table
                       where a.Roles.Any(r => r.Name == "Assistant")
                       select new AssistantModel
                       {
                           Id = a.Id,
                           FirstName = a.UserProfile.FirstName,
                           LastName = a.UserProfile.LastName,
                           UserName=a.UserName,
                           PersonalEmail = a.UserProfile.PersonalEmail,
                           MobileNo = a.UserProfile.MobileNo,
                           DateOfBirth = a.UserProfile.DateOfBirth,
                           UserCode = a.UserProfile.UserCode,
                           CountryId = a.UserProfile.CountryId,
                           LanguageId = a.UserProfile.LanguageId,
                           ModifiedDate = a.UserProfile.ModifiedDate,
                           CreatedBy = a.UserProfile.CreatedBy,
                           ModifiedBy = a.UserProfile.ModifiedBy,
                           CreatedDate = a.UserProfile.CreatedDate
                       };
            return data.ToList();
        }

        public AssistantModel GetAssistantByID(double id)
        {
            var data = from a in this._userProfileRepository.Table
                       where a.Id == id
                       select new AssistantModel
                       {
                           Id = a.Id,
                           FirstName = a.FirstName,
                           LastName = a.LastName,
                           PersonalEmail = a.PersonalEmail,
                           MobileNo = a.MobileNo,
                           DateOfBirth = a.DateOfBirth,
                           UserCode = a.UserCode,
                           UserName = a.Users.FirstOrDefault().UserName,
                           CountryId = a.CountryId,
                           LanguageId = a.LanguageId,
                           ModifiedDate = a.ModifiedDate,
                           CreatedBy = a.CreatedBy,
                           ModifiedBy = a.ModifiedBy,
                           CreatedDate = a.CreatedDate,
                       };

            return data.FirstOrDefault();
        }

       
    }
}
