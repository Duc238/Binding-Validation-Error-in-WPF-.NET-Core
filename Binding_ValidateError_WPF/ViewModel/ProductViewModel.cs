using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Binding_ValidateError_WPF.ViewModel
{
    public class ProductViewModel:BaseViewModel, IDataErrorInfo
    {
        private string _productName = "";
        private int _quantity;
        public string ProductName
        {
            get => _productName;
            set
            {
                if (_productName == value) return;

                _productName = value;
                OnPropertyChanged();
            }
        }
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity == value) return;

                _quantity = value;
                OnPropertyChanged();
            }
        }
        // Kiểm tra lỗi theo từng thuộc tính
        public string this[string columnName]
        {
            get
            {
                return columnName switch
                {
                    nameof(ProductName) when
                        string.IsNullOrWhiteSpace(ProductName)
                        => "Tên sản phẩm không được để trống!",
                    nameof(Quantity) when Quantity <= 0
                        => "Số lượng phải lớn hơn 0!",
                    _ => string.Empty
                };
            }
        }

        // Lỗi tổng thể của ViewModel
        public string Error => string.Empty;

    }
}
