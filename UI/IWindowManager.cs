
using DataAccess.Entities;
using BusinessObjects.Entities;

namespace UI;

public interface IWindowManager
{
    void ShowAdminWindow();
    void ShowCustomerWindow();
    void CloseLoginWindow();
    void ShowCarManagementWindow();
    void ShowCustomerManagementWindow();
    void ShowRentingTransactionWindow();
    void ShowCarInformationForm();
    void ShowCarInformationEditForm(CarInformation selectedCarInformation);
    void CloseCarInformationForm();
    void RefreshCarManagementWindow();
    void ShowCustomerFormWindow();
    void CloseCustomerFormWindow();
    void ShowCustomerProfileWindow();
    void ShowCustomerEditProfileWindow(Customer currentCustomer);
}