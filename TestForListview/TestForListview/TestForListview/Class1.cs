using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestForListview {
    public class Condition {
        public string Name { get; set; }
        public string Decision { get; set; }
    }
    public class ConditionData {
        #region ConditionList
        public static ObservableCollection<Condition> ConditionList = new ObservableCollection<Condition> {
            new Condition {Name = "AIDS" ,                              Decision = "No"       },

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
