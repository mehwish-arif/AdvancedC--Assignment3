﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CareerCloud.BusinessLogicLayer
{
  public  class SystemLanguageCodeLogic
    {
		protected IDataRepository<SystemLanguageCodePoco> _repository;

		public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
        {
			_repository = repository;
        }

		
		public void Delete(SystemLanguageCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Remove(pocos);
		}

		public List<SystemLanguageCodePoco> GetAll()
		{
			
			return _repository.GetAll().ToList();
		}

		public void Add(SystemLanguageCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Add(pocos);
		}

		public void Update(SystemLanguageCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Update(pocos);
		}


		public SystemLanguageCodePoco Get(string languageid)
		{
			return _repository.GetSingle(c => c.LanguageID == languageid);
		}
		protected void Verify(SystemLanguageCodePoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();


			foreach (SystemLanguageCodePoco poco in pocos)
			{
				if (string.IsNullOrEmpty(poco.LanguageID))

				{
					exceptions.Add(new ValidationException(1000, "Code Cannot be empty"));
				}

				if (string.IsNullOrEmpty(poco.Name))
				{
					exceptions.Add(new ValidationException(1001, "Name cannot be empty"));
				}


				if (string.IsNullOrEmpty(poco.NativeName))
				{
					exceptions.Add(new ValidationException(1002, "Native Name cannot be empty"));
				}
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}

	}
}
