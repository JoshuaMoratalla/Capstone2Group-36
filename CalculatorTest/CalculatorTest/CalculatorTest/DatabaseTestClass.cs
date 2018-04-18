using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest {
    public class Condition
    {
        public string Name { get; set; }
        public string Decision { get; set; }
        public string Description { get; set; }
    }
    public class ConditionData
    {
        #region ConditionList
        public static ObservableCollection<Condition> ConditionList = new ObservableCollection<Condition>
        {
            new Condition {Name = "AIDS", Decision = "No", Description = "testing"},
            new Condition {Name = "Acanthamoeba" ,                      Decision = "Refuse", Description = "testing"   },
            new Condition {Name = "Accident" ,                          Decision = "Maybe", Description = "testing"    },
            new Condition {Name = "Achondroplasia" ,                    Decision = "Accept", Description = "testing"   },
            new Condition {Name = "Acne" ,                              Decision = "Maybe", Description = "Secondary infection of acne is usually obvious with swelling and redness of affected spots. There is a risk of bacteria entering the blood. This could be a serious threat to anybody receiving tissues other than ocular as the bacteria can multiply to dangerous levels. For corneas preserved by organ culture (but not hypothermic) there is an opportunity to detect contaminating bacteria in the tissue and it should be safe to donate, but if there is no ocular involvement hypothermic storage would also present no significant risk. Secondary infection of the lid margin (blepharitis) on its own should not preclude eye donation, but donations must not be taken if there is also ocular surface disease. Secondary infection of acne is usually obvious with swelling and redness of affected spots. There is a risk of bacteria entering the blood. This could be a serious threat to anybody receiving tissues other than ocular as the bacteria can multiply to dangerous levels. For corneas preserved by organ culture (but not hypothermic) there is an opportunity to detect contaminating bacteria in the tissue and it should be safe to donate, but if there is no ocular involvement hypothermic storage would also present no significant risk. Secondary infection of the lid margin (blepharitis) on its own should not preclude eye donation, but donations must not be taken if there is also ocular surface disease."    },
            new Condition {Name = "Acne - treatment" ,                  Decision = "Accept", Description = "testing"   },
            new Condition {Name = "Acne - roscea" ,                     Decision = "Accept", Description = "testing"   },
            new Condition {Name = "Acupuncture" ,                       Decision = "Accept", Description = "testing"   },
            new Condition {Name = "Addiction and drug abuse" ,          Decision = "Refuse", Description = "testing"   },
            new Condition {Name = "African Trypanosomiasis" ,           Decision = "Accept", Description = "testing"   },
            new Condition {Name = "Age" ,                               Decision = "Accept", Description = "testing"   },
            new Condition {Name = "Age-related Macular Degeneration" ,  Decision = "Accept", Description = "testing"   }
        };
        #endregion


        /*
         *
         * new Condition {Name = "AIDS" ,                              Decision = "No"       },

            new Condition {Name = "Acanthamoeba" ,                      Decision = "Refuse"   },
            new Condition {Name = "Accident" ,                          Decision = "Maybe"    },
            new Condition {Name = "Achondroplasia" ,                    Decision = "Accept"   },
            new Condition {Name = "Acne" ,                              Decision = "Maybe"    },
            new Condition {Name = "Acne - treatment" ,                  Decision = "Accept"   },
            new Condition {Name = "Acne - roscea" ,                     Decision = "Accept"   },
            new Condition {Name = "Acupuncture" ,                       Decision = "Accept"   },
            new Condition {Name = "Addiction and drug abuse" ,          Decision = "Refuse"   },
            new Condition {Name = "African Trypanosomiasis" ,           Decision = "Accept"   },
            new Condition {Name = "Age" ,                               Decision = "Accept"   },
            new Condition {Name = "Age-related Macular Degeneration" ,  Decision = "Accept"   }


        new Condition {Decision = "No"       },

            new Condition {Decision = "Refuse"   },
            new Condition {Decision = "Maybe"    },
            new Condition {Decision = "Accept"   },
            new Condition {Decision = "Maybe"    },
            new Condition {Decision = "Accept"  },
            new Condition {Decision = "Accept"   },
            new Condition {Decision = "Accept"   },
            new Condition {Decision = "Refuse"   },
            new Condition {Decision = "Accept"   },
            new Condition {Decision = "Accept"   },
            new Condition {Decision = "Accept"   }
         */


    }
}
