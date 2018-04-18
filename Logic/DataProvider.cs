using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Runtime;

namespace Logic

{
    public class DataProvider
    {
        private CandidatesManager _CandidatesManager;
        
        public CandidatesManager candidatesManager
        {
            get
            {
                if (_CandidatesManager == null)
                    _CandidatesManager = new CandidatesManager();
                return _CandidatesManager;
            }
        }
      


      private OtherManager _OtherManager;
      public OtherManager OtherManager
        {
            get
            {
                if (_OtherManager == null)
                    _OtherManager = new OtherManager();
                return _OtherManager;
            }
        }
        
        
        private CompanyManager _companyManager;


        public CompanyManager companyManager
        {
            get
            {
                if (_companyManager == null)
                    _companyManager = new CompanyManager();
                return _companyManager;
            }
        }


    }
}
