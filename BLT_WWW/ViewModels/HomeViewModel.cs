namespace BLT.WWW.ViewModels {
    using System;
    using System.Collections.Generic;

    public class HomeViewModel
    {
        private IList<RecruitingNeedViewModel> _RecruitingNeeds = new List<RecruitingNeedViewModel>();
        public IList<RecruitingNeedViewModel> RecruitingNeeds { 
            get
            {
                return _RecruitingNeeds;
            }
        }
    }
}