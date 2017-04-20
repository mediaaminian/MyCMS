using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


public enum MessageTypeEnum
{
    alert, success, error,
    warning, information, confirm
}

public enum MessageLocationEnum
{
    top, topleft, topcenter, topright, centerleft, center, centerright, bottomleft, bottomcenter, bottomright, bottom
}

[Flags]
public enum SessionNames { Order };

[Flags]
public enum CookieNames { UserID };

[Flags]
public enum FrameworkRole { Admin, Agent, Operator, Support, GoldClient, SilverClient, BronzeClient };

[Flags]
public enum OrderStatus { InBasket = 0, Expired, CompleteByUser, InToDoList };

[Flags]
public enum OrderDetailStatus { InBasket = 0, AssignToSupport };

[Flags]
public enum BuiltInEntityState
{
    IsInTrash = 127,
    IsArcived = 126,
    IsDeleted = 125
}
[Flags]
public enum EventVariableKeyEnum
{

    UserGroup = 1001,
    OrderPrice = 1002,
    ExpireDate = 1003,
    OrderProduct = 1004,
    OrderProductType = 1005,
    Brithday = 1006,
    Sex = 1007,
    ServiceProduct = 1008,
    OrderDate = 1009,
    ExpireDateDay = 1010,
    OrderDateDay = 1011,
    GroupCondition = 1012,
    TimePattern = 1013,
    ModuleId = 1014,
    UserId = 1015,
    RecieptPaid = 1016,
    OrderRegister = 1017,
    Service = 1018,
    ProductTypeId = 1019,
    ProductTypeGroupId = 1020,
    IsExtra = 1021,
    Fee = 1022,
    Username = 1023,
    StartDate = 1024,
    Product = 1025
}
[Flags]
public enum TypeOperatorEnum
{
    sEqual = 101,
    sNotEqual = 102,
    sContains = 103,
    sNotContain = 104,
    sStartsWith = 105,
    sEndsWith = 106,


    iEqual = 111,
    iNotEqual = 112,
    iLessThan = 113,
    iGreaterThan = 114,
    iLessThanOrEqual = 115,
    iGreaterThanOrEqual = 116,


    dEqual = 121,
    dNotEqual = 122,
    dLessThan = 123,
    dGreaterThan = 124,
    dLessThanOrEqual = 125,
    dGreaterThanOrEqual = 126,

    bEqual = 141,
    bNotEqual = 142,

    tEqual = 151,
}
[Flags]
public enum OperatorEnum
{
    And = 1,
    Or = 2
}


namespace Framework.UI.Web
{
    public enum UsesDiscountEnum
    {
        ProductTypeGroup = 1,
        ProductType = 2,
        Product = 3,
        Event = 4

    }
}

/// <summary>
/// <asp:DropDownList ID="myDDL"
///    DataTextField="Description"
///                  DataValueField="Value" />

///myDDL.DataSource = Enum.GetValues(typeof(MyEnum)).OfType<MyEnum>().Select(
///    val => new { Description = val.GetDescription(), Value = val.ToString() });

///myDDL.DataBind();
/// </summary>
/// <param name="value"></param>
/// <returns></returns>
public enum enumDataType : byte
{
    [Description("عددی")]
    Int = 1,
    [Description("متنی")]
    String = 2,
    [Description("عددی اعشاری")]
    Float = 3,
    [Description("بلی/خیر")]
    Boolean = 4,
    [Description("نرخ")]
    Currency = 5,
    [Description("تصویر")]
    Image = 6,
    [Description("لینک")]
    Hyperlink = 7,
    [Description("لیست تک انتخابی")]
    SingleChoice = 8,
    [Description("لیست چند انتخابی")]
    MultipleChoice = 9,
    [Description("سال شمسی")]
    ShamsiYear = 10,
    [Description("سال میلادی")]
    GregorianYear = 11,
    [Description("محصول دیگر")]
    RelatedProduct = 12,
}

[Flags]
public enum Gender
{
    Man = 1,
    Woman = 2
}

[Flags]
public enum MenuType : byte
{
    ExternalLink = 1,
    InternalDynamicLink = 2,
    InternalStaticLink = 4,

};

[Flags]
public enum MenuViewType
{
    Accordion = 1,
    FullWidth = 2,
    Normal = 4
}

[Flags]
public enum Area
{
    Admin = 1,
    Client = 2,
    FrontEnd = 4
}

[Flags]
public enum TargetType
{
    _blank = 1,
    _self = 2,
    _parent = 4,
    _top = 8
}

[Flags]
public enum UserType
{
    Technical = 1,
    Billing = 2,
    Registration = 3,
    Administrator = 4,
    regular = 5,
    ilegall = 6

}


public enum EnumModuleType
{
    //Registrar = 1,
    RegisterDomain = 1,
    ControlPanel = 2,
    Mail = 3,
    Payment = 4,
    Monitoring = 5,
    Sitebuilder = 6,
    SMS = 7,
    Fax = 8
}

public enum EnumModule
{
    Pasargad = 1,
    Mellat = 2,
    Saman = 3,
    Parsian = 4,
    Offline = 5

}

public enum EnumPaymentStatus
{
    Enable = 1,
    Disable = 2,
    SendToBank = 3,
    Unallocated = 4,
    PendingApprovalByBank = 5

}


public enum EnumStatus
{
    IsEnable = 1,
    IsInTrash = 127,
    IsArcived = 126,
    IsDeleted = 125

}

public enum AppKeyEnum
{
    Domain = 1,
    WebHost = 2,
    DedicateServer = 3,
    Email = 4,
    PrivateHost = 5,
    PrivateReseller = 6,
    AffiliateReseller = 7,
    FireWall = 8,
    BackUpService = 9,
    MonitoringService = 10


}

public enum ServiceStatusEnum : byte
{
    NotPaid = 1,
    Pending = 2,
    Active = 3,
    Suspend = 4,
    PendingExpire = 5,
    Expire = 6,
    Deleted = 7,
    Transfering = 8,
    Active_Lock = 9,
    PendingExpire_Lock = 10

}
public enum OrderStatusEnum
{
    NotPaid = 1,
    Pending = 2,
    Active = 3,
    Suspend = 4,
    PendingExpire = 5,
    Expire = 6,
    Deleted = 7

}

public enum CaseTypeEnum
{
    Renewed = 1,
    NewOrder = 2,
    SatisfactionAfterRenewed = 3,
    SatisfactionAfterSale = 4

}

[Flags]
public enum AlertJobStatusEnum
{
    Sent = 1, Wait = 2, Failed = 3
};

[Flags]
public enum AlertJobTypeStatusEnum
{
    SMS = 1, Mail = 2, Message = 3, Notification = 4, Fax = 5
};

public enum AlertType
{
    SMS = 1,
    Email = 2,
    Fax = 3,
    Message = 4,
    Notification = 5

}

public enum ActionTypeEnum
{
    Alert = 1,
    Case = 2,
    Module = 3,
    Coupon = 4,
    Discount = 5
}

public enum TemplateType
{
    Call,
    Fax,
    Mail,
    Message,
    SMS
}

// YB
public enum EnumOrderDetailOperationType : byte
{
    RegisterDomain = 0,
    TransferDomain = 1,
    RenewDomain = 2,
    ChangeDns = 3
}
public enum enumToDoList : byte
{
    Done = 1,
    Pending = 2,
    InPregress = 3,
    NotDone = 4,
    Failed = 5,
    Waiting = 6
}
public enum enumNicCommandResult
{
    CommandCompletedSuccessfully = 1000,
    CommandCompletedSuccessfullyActionPending = 1001,
    CommandCompletedSuccessfullyNoMessages = 1300,
    CommandCompletedSuccessfullyAckToDequeue = 1301,
    UnknownCommand = 2000,
    CommandSyntaxError = 2001,
    RequiredParameterMissing = 2003,
    ParameterValueRangeError = 2004,
    ParameterValueSyntaxError = 2005,
    UnimplementedCommand = 2101,
    BillingFailure = 2101,
    ObjectIsNotEligibleForRenewal = 2105,
    AuthenticationError = 2200,
    AuthorizationError = 2201,
    InvalidAuthorizationInformation = 2202,
    ObjectExists = 2302,
    ObjectDoesNotExist = 2303,
    ObjectStatusProhibitsOperation = 2304,
    ParameterValuePolicyError = 2306,
    DataManagementPolicyViolation = 2308,
    CommandFailed = 2400
}


public enum enumRegistrationProfile
{
    Done = 1,
    Pending = 2,
}
public enum enumModules
{
    OfflineModule = 1,
    NicModule = 9,
    ReselloModule = 2,
    DirectI = 3,
    OnlineNicModule = 4,
    PasargadModule = 5,
    MellatModule = 6,
    SamanModule = 7,
    ParsianModule = 8,
    SMSModule = 10,
    MailModule = 21,
    FaxModule = 12,
    WebSitePanel = 13,
    Helm = 14,
    TestNicModule = 15
}

public enum enumMailStatus
{
    Waiting = 1,
    Done = 2,
    Failed = 3,
    InProgress = 4
}

// SM
public enum enumPayType : byte
{
    Cash = 1,
    Fish = 2,
    Card = 3
}


public enum enumCouponType : byte
{
    Automatically = 1,
    Manual = 2
}
public enum enumTypeTime : byte
{
    Schedule = 1,
    RealTime = 2
}
