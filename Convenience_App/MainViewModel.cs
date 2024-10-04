using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Convenience_App
{
    class MainViewModel : MainViewModelBase
    {
        private Calculators calcular_ = null;
        private int result_ = 0;
        private int value1_ = 0;
        private int value2_ = 0;
        private bool isAddChecked_ = false;
        private bool isSubtractChecked_ = false;
        private bool isMultiplyChecked_ = false;
        private bool isDivideChecked_ = false;
        private bool isAnyRadioBtnChecked_ = false;

        public bool IsAnyRadioBtnChecked
        {
            get
            {
                return isAnyRadioBtnChecked_;
            }
            set
            {
                isAnyRadioBtnChecked_ = value;
                OnPropertyChanged("IsAnyRadioBtnChecked");
            }
        }

        public int Value1
        {
            get
            {
                return value1_;
            }
            set
            {
                value1_ = value;
                OnPropertyChanged("Value1");
            }
        }

        public int Value2
        {
            get
            {
                return value2_;
            }
            set
            {
                value2_ = value;
                OnPropertyChanged("Value2");
            }
        }

        public int Result
        {
            get
            {
                return result_;
            }
            set
            {
                if (value != result_) //* Luu y co the loi ngay o day
                {
                    result_ = value;
                    OnPropertyChanged("Result");
                }
            }
        }

        public bool IsAddChecked
        {
            get
            {
                return isAddChecked_;
            }
            set
            {
                if (value != isAddChecked_)
                {
                    isAddChecked_ = value;
                    IsAnyRadioBtnChecked = true;
                    OnPropertyChanged("IsAddChecked");
                }
            }
        }

        public bool IsSubtractChecked
        {
            get
            {
                return isSubtractChecked_;
            }
            set
            {
                if (value != isSubtractChecked_)
                {
                    isSubtractChecked_ = value;
                    IsAnyRadioBtnChecked = true;
                    OnPropertyChanged("IsSubtractChecked");
                }
            }
        }

        public bool IsMultiplyChecked
        {
            get
            {
                return isMultiplyChecked_;
            }
            set
            {
                if (value != isMultiplyChecked_)
                {
                    isMultiplyChecked_ = value;
                    IsAnyRadioBtnChecked = true;
                    OnPropertyChanged("IsMultiplyChecked");
                }
            }
        }

        public bool IsDivideChecked
        {
            get
            {
                return isDivideChecked_;
            }
            set
            {
                if (value != isDivideChecked_)
                {
                    isDivideChecked_ = value;
                    IsAnyRadioBtnChecked = true;
                    OnPropertyChanged("IsDivideChecked");
                }
            }
        }

        public ICommand OkButtonClicked
        {
            get
            {
                return new DelegateCommand(FindResult);
            }
        }

        public void FindResult()
        {
            calcular_ = new Calculators(Value1, Value2);
            if (IsAddChecked)
            {
                Result = calcular_.Add();
            }
            else if (IsSubtractChecked)
            {
                Result = calcular_.Subtract();
            }
            else if (IsMultiplyChecked)
            {
                Result = calcular_.Multiply();
            }
            else if (IsDivideChecked)
            {
                Result = calcular_.Divide();
            }
        }
    }
}
