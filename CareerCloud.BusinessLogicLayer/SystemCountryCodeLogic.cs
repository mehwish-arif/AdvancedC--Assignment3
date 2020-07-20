﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CareerCloud.BusinessLogicLayer
{
  public class SystemCountryCodeLogic 
    {
		
		protected IDataRepository<SystemCountryCodePoco> _repository;
		public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository) 
        {
			_repository = repository;
		}

		public void Delete(SystemCountryCodePoco[] pocos)
		{
			_repository.Remove(pocos);
		}

     	public  List<SystemCountryCodePoco> GetAll()
		{
			return _repository.GetAll().ToList();
		}

		public  void Add(SystemCountryCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Add(pocos);
		}

		public void Update(SystemCountryCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Update(pocos);
		}

		
		public SystemCountryCodePoco Get(string code)
		{
			return _repository.GetSingle(c => c.Code == code);
		}
		protected void Verify(SystemCountryCodePoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();

			foreach (SystemCountryCodePoco poco in pocos)
            {
				if(string.IsNullOrEmpty(poco.Code))

					 {
					exceptions.Add(new ValidationException(900, "Code Cannot be empty"));
					 }

				if(string.IsNullOrEmpty(poco.Name))
                {
					exceptions.Add(new ValidationException(901, "Name cannot be empty"));
                }
	        }


			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}

	}
}

  