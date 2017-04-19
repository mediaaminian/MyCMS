using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace MyCMS.Utilities
{
    public class DataDictionary
    {
        
        public static Dictionary<int, string> AlertTypeDictionary
        {
            get
            {
                var _alertType = new Dictionary<int, string>();

                _alertType.Add(Convert.ToInt32(AlertType.SMS), AlertType.SMS.ToString());
                _alertType.Add(Convert.ToInt32(AlertType.Email), AlertType.Email.ToString());
                _alertType.Add(Convert.ToInt32(AlertType.Fax), AlertType.Fax.ToString());
                _alertType.Add(Convert.ToInt32(AlertType.Message), AlertType.Message.ToString());
                _alertType.Add(Convert.ToInt32(AlertType.Notification), AlertType.Notification.ToString());



                return _alertType;


            }
        }

        public static Dictionary<int, Tuple<string, string>> BuiltInDictionary
        {
            get
            {
                var BuiltInItems = new Dictionary<int, Tuple<string, string>>();
                BuiltInItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                BuiltInItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                BuiltInItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));
                return BuiltInItems;
            }
        }

        #region[ Custom Status ]


        public static Dictionary<int, Tuple<string, string>> IsActiveItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "می باشد"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "نمی باشد"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> IsSpecialItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "می باشد"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "نمی باشد"));
                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> IsUpgradeableItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "می باشد"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "نمی باشد"));
                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> IsRecommendedItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "می گردد"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "نمی گردد"));
                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> IsExtraItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "می باشد"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "نمی باشد"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> IsAvailableItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "می باشد"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "نمی باشد"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> IsMultiSelectItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "دارد"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "ندارد"));

                return StatusItems;
            }
        }




        #endregion

        #region [ Event Condition Dictionary ]



        public static Dictionary<EventVariableKeyEnum, Tuple<Type, string, string, string, PropertyInfo>>
            EventVariableKeyDictionary
        {
            get
            {
                var data = new Dictionary<EventVariableKeyEnum, Tuple<Type, string, string, string, PropertyInfo>>();

                data.Add(EventVariableKeyEnum.UserGroup,new Tuple<Type, string, string, string, PropertyInfo>(typeof (bool), "سطح کاربر", "EventCondition","GetRole", null));
                data.Add(EventVariableKeyEnum.ServiceProduct,new Tuple<Type, string, string, string, PropertyInfo>(typeof (bool), "محصول در سرویس","EventCondition", "GetProduct", null));
                data.Add(EventVariableKeyEnum.OrderProduct,new Tuple<Type, string, string, string, PropertyInfo>(typeof (bool), "محصول در سبد","EventCondition", "GetProduct", null));
                data.Add(EventVariableKeyEnum.OrderProductType,new Tuple<Type, string, string, string, PropertyInfo>(typeof (bool), "نوع محصول در سبد","EventCondition", "GetProductType", null));
                data.Add(EventVariableKeyEnum.OrderPrice,new Tuple<Type, string, string, string, PropertyInfo>(typeof (int), "مبلغ سفارش", "", "", null));
                data.Add(EventVariableKeyEnum.ExpireDate,new Tuple<Type, string, string, string, PropertyInfo>(typeof (DateTime), "تاریخ انقضا", "", "", null));
                data.Add(EventVariableKeyEnum.ExpireDateDay,new Tuple<Type, string, string, string, PropertyInfo>(typeof (int), "تاریخ انقضا روز", "", "", null));
                data.Add(EventVariableKeyEnum.OrderDateDay,new Tuple<Type, string, string, string, PropertyInfo>(typeof (int), "تاریخ سقارش روز", "", "", null));
                data.Add(EventVariableKeyEnum.OrderDate,new Tuple<Type, string, string, string, PropertyInfo>(typeof (DateTime), "تاریخ سقارش", "", "", null));
                data.Add(EventVariableKeyEnum.Brithday,new Tuple<Type, string, string, string, PropertyInfo>(typeof (DateTime), "تاریخ تولد", "", "", null));
                data.Add(EventVariableKeyEnum.Sex,new Tuple<Type, string, string, string, PropertyInfo>(typeof (bool), "کاربر", "EventCondition","GetUser", null));
                data.Add(EventVariableKeyEnum.GroupCondition,new Tuple<Type, string, string, string, PropertyInfo>(typeof (bool), "گروه شرط", "EventCondition","GetGroupCondition", null));

                
                data.Add(EventVariableKeyEnum.TimePattern, new Tuple<Type, string, string, string, PropertyInfo>(typeof(TimeSpan), "الگوی زمانی", "", "", null));
                data.Add(EventVariableKeyEnum.ModuleId, new Tuple<Type, string, string, string, PropertyInfo>(typeof(int), " شناسه ماجول", "", "", null));
                data.Add(EventVariableKeyEnum.UserId, new Tuple<Type, string, string, string, PropertyInfo>(typeof(Guid), "شناسه کاربری ", "", "", null));
                data.Add(EventVariableKeyEnum.RecieptPaid, new Tuple<Type, string, string, string, PropertyInfo>(typeof(string), "پرداخت صورتحساب", "", "", null));



                data.Add(EventVariableKeyEnum.ProductTypeId, new Tuple<Type, string, string, string, PropertyInfo>(typeof(string), "نوع محصول", "", "", null));
                data.Add(EventVariableKeyEnum.ProductTypeGroupId, new Tuple<Type, string, string, string, PropertyInfo>(typeof(string), "گروه نوع محصول", "", "", null));
                data.Add(EventVariableKeyEnum.IsExtra, new Tuple<Type, string, string, string, PropertyInfo>(typeof(string), "امکان جانبی", "", "", null));
                data.Add(EventVariableKeyEnum.Fee, new Tuple<Type, string, string, string, PropertyInfo>(typeof(string), "هزینه سرویس", "", "", null));
                data.Add(EventVariableKeyEnum.Username, new Tuple<Type, string, string, string, PropertyInfo>(typeof(string), "نام کاربری", "", "", null));
                data.Add(EventVariableKeyEnum.Product, new Tuple<Type, string, string, string, PropertyInfo>(typeof(string), " محصول ", "", "", null));
                data.Add(EventVariableKeyEnum.StartDate, new Tuple<Type, string, string, string, PropertyInfo>(typeof(string), " محصول ", "", "", null));
                data.Add(EventVariableKeyEnum.Service, new Tuple<Type, string, string, string, PropertyInfo>(typeof(string), " محصول ", "", "", null));
                
                return data;
            }
        }

        public static List<Tuple<TypeOperatorEnum, Type, string>> TypeOperatorEnumDictionary
        {
            get
            {
                var data = new List<Tuple<TypeOperatorEnum, Type, string>>();



                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.iLessThan, typeof (int), "کوچکتر"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.iGreaterThan, typeof(int), "بزرگتر"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.iEqual, typeof (int), "مساوی"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.iNotEqual, typeof (int), "مخالف"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.iLessThanOrEqual, typeof (int),
                    "کوچکتر مساوی"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.iGreaterThanOrEqual, typeof(int),
                    "بزرگتر مساوی"));


                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.sContains, typeof (string), "شامل"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.sNotContain, typeof (string),
                    "غیر شامل"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.sEqual, typeof (string), "مساوی"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.sNotEqual, typeof (string), "مخالف"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.sStartsWith, typeof (string),
                    "شروع با"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.sEndsWith, typeof (string),
                    "خاتمه با"));




                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.bNotEqual, typeof (bool), "مساوی"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.bEqual, typeof (bool), "مخالف"));

                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.tEqual, typeof (TimeSpan), "مساوی"));


                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.dLessThan, typeof (DateTime),
                    "کوچکتر"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.dGreaterThan, typeof (DateTime),
                    "بزرگتر"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.dEqual, typeof (DateTime), "مساوی"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.dNotEqual, typeof (DateTime),
                    "مخالف"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.dLessThanOrEqual, typeof (DateTime),
                    "کوچکتر مساوی"));
                data.Add(new Tuple<TypeOperatorEnum, Type, string>(TypeOperatorEnum.dGreaterThanOrEqual, typeof(DateTime),
                    "بزرگتر مساوی"));






                return data;
            }
        }

        public static Dictionary<OperatorEnum, Tuple<string, string>> OperatorEnumDictionary
        {
            get
            {
                var data = new Dictionary<OperatorEnum, Tuple<string, string>>();


                data.Add(OperatorEnum.And, new Tuple<string, string>("And", "و"));
                data.Add(OperatorEnum.Or, new Tuple<string, string>("Or", "یا"));



                return data;
            }
        }


        #endregion

        #region [ Entity Status ]

        public static Dictionary<int, Tuple<string, string>> DomainNameServerStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }



        public static Dictionary<int, Tuple<string, string>> ServiceStatusItems
        {
            get
            {
                var BuiltInItems = new Dictionary<int, Tuple<string, string>>();
                BuiltInItems.Add((int) ServiceStatusEnum.NotPaid, new Tuple<string, string>("Not Paid", "پرداخت نشده"));
                BuiltInItems.Add((int) ServiceStatusEnum.Pending,
                    new Tuple<string, string>("Pending", "در انتظار فعال سازی"));
                BuiltInItems.Add((int) ServiceStatusEnum.Active, new Tuple<string, string>("Active", "فعال"));
                BuiltInItems.Add((int) ServiceStatusEnum.Suspend, new Tuple<string, string>("Suspend", "غیر فعال"));
                BuiltInItems.Add((int) ServiceStatusEnum.PendingExpire,
                    new Tuple<string, string>("Pending Expire", "در حال انقضا"));
                BuiltInItems.Add((int) ServiceStatusEnum.Expire, new Tuple<string, string>("Expire", "منقضی"));
                BuiltInItems.Add((int) ServiceStatusEnum.Deleted, new Tuple<string, string>("Deleted", "حذف شده"));
                BuiltInItems.Add((int) ServiceStatusEnum.Transfering,
                    new Tuple<string, string>("Transfering", "در حال انتقال"));
                BuiltInItems.Add((int) ServiceStatusEnum.Active_Lock,
                    new Tuple<string, string>("Acive-Lock", "فعال-قفل"));
                BuiltInItems.Add((int) ServiceStatusEnum.PendingExpire_Lock,
                    new Tuple<string, string>("Pending Expire-Lock", "در حال انقضاء-قفل"));
                return BuiltInItems;
            }
        }

        // YB
        public static Dictionary<int, Tuple<string, string>> ToDoListStatusItems2
        {
            get
            {
                var toDoListItems = new Dictionary<int, Tuple<string, string>>();
                toDoListItems.Add((int) enumToDoList.Done, new Tuple<string, string>("Done", "انجام شده"));
                toDoListItems.Add((int) enumToDoList.Pending, new Tuple<string, string>("Pending", "در انتظار انجام"));
                toDoListItems.Add((int) enumToDoList.InPregress,
                    new Tuple<string, string>("In Pregress", "در حال انجام"));
                toDoListItems.Add((int) enumToDoList.NotDone, new Tuple<string, string>("Not Done", "غیر قابل اجام"));
                toDoListItems.Add((int) enumToDoList.Failed, new Tuple<string, string>("Failed", "ناموفق"));
                return toDoListItems;
            }
        }

        public static Dictionary<int, string> CaseServiceStatusItems
        {
            get
            {
                var BuiltInItems = new Dictionary<int, string>();
                //BuiltInItems.Add((int)ServiceStatusEnum.NotPaid, new Tuple<string, string>("Not Paid", "پرداخت نشده"));
                //BuiltInItems.Add((int)ServiceStatusEnum.Pending, new Tuple<string, string>("Pending", "در انتظار فعال سازی"));
                //BuiltInItems.Add((int)ServiceStatusEnum.Active, new Tuple<string, string>("Active", "فعال"));
                //BuiltInItems.Add((int)ServiceStatusEnum.Suspend, new Tuple<string, string>("Suspend", "غیر فعال"));
                //BuiltInItems.Add((int)ServiceStatusEnum.PendingExpire, new Tuple<string, string>("Pending Expire", "در حال انقضا"));
                //BuiltInItems.Add((int)ServiceStatusEnum.Expire, new Tuple<string, string>("Expire", "منقضی"));
                //BuiltInItems.Add((int)ServiceStatusEnum.Deleted, new Tuple<string, string>("Deleted", "حذف شده"));
                //BuiltInItems.Add((int)ServiceStatusEnum.Transfering, new Tuple<string, string>("Transfering", "در حال انتقال"));
                //BuiltInItems.Add((int)ServiceStatusEnum.Active_Lock, new Tuple<string, string>("Acive-Lock", "فعال-قفل"));
                //BuiltInItems.Add((int)ServiceStatusEnum.PendingExpire_Lock, new Tuple<string, string>("Pending Expire-Lock", "در حال انقضاء-قفل"));

                BuiltInItems.Add(1, "نامشخص");
                BuiltInItems.Add(2, "طراحی دارند و راضی هستند");
                BuiltInItems.Add(3, "طراحی ندارند و راهنمایی شد");
                BuiltInItems.Add(4, "نماینده اعتباری");
                BuiltInItems.Add(5, "عدم دسترسی");
                BuiltInItems.Add(6, "عدم رضایت از پشتیبانی");
                BuiltInItems.Add(7, "عدم رضایت از نحوه برخورد");
                BuiltInItems.Add(8, "عدم رضایت از میزان منابع");
                BuiltInItems.Add(9, "عدم رضایت از سرعت سرور");
                BuiltInItems.Add(10, "عدم رضایت از پایداری سرویس");
                return BuiltInItems;

            }
        }


        public static Dictionary<int, string> TransationTypeItems
        {
            get
            {
                var TransationTypeItems = new Dictionary<int, string>();

                TransationTypeItems.Add(1, "نقدى");
                TransationTypeItems.Add(53, "انتقالى ازكارت");

                //TransationTypeItems.Add(0, "انتقال به كارت - شتا");
                //TransationTypeItems.Add(3, "انتقالى");
                //TransationTypeItems.Add(5, "انتقال اينترنتى");
                //TransationTypeItems.Add(6, "برداشت با POS");
                //TransationTypeItems.Add(7, "حواله پايا");
                //TransationTypeItems.Add(8, "برداشت ATM");
                //TransationTypeItems.Add(9, "واريز با PINPAD");

                return TransationTypeItems;

            }
        }

        public static Dictionary<byte, Tuple<string, string>> CaseStatusItems
        {
            get
            {
                var caseStatusItem = new Dictionary<byte, Tuple<string, string>>();
                caseStatusItem.Add(1, new Tuple<string, string>("Open", "باز"));
                caseStatusItem.Add(2, new Tuple<string, string>("Close", "بسته"));
                caseStatusItem.Add(3, new Tuple<string, string>("Cancel", "لغو"));
                return caseStatusItem;
            }

        }

        public static Dictionary<byte, string> OnlineStatusDictionary
        {
            get
            {
                var OnlineStatusDictionary = new Dictionary<byte, string>();
                OnlineStatusDictionary.Add(1, "آنلاین");
                OnlineStatusDictionary.Add(2, "آفلاین");

                return OnlineStatusDictionary;
            }

        }

        public static Dictionary<int, string> CaseTypeDictionary
        {
            get
            {
                var CaseTypeDictionary = new Dictionary<int, string>();
                //OnlineStatusItem.Add(1, new Tuple<string, string>("Enable", "فعال"));

                return CaseTypeDictionary;
            }

        }

        public static Dictionary<byte, Tuple<string, string>> PaymentModuleItems
        {
            get
            {
                var paymentModuleItems = new Dictionary<byte, Tuple<string, string>>();
                paymentModuleItems.Add((byte) EnumModule.Pasargad, new Tuple<string, string>("Pasargad", "پاسارگاد"));
                paymentModuleItems.Add((byte) EnumModule.Mellat, new Tuple<string, string>("Mellat", "ملت"));
                paymentModuleItems.Add((byte) EnumModule.Saman, new Tuple<string, string>("Saman", "سامان"));
                paymentModuleItems.Add((byte) EnumModule.Parsian, new Tuple<string, string>("Parsian", "پارسیان"));
                paymentModuleItems.Add((byte) EnumModule.Offline, new Tuple<string, string>("Offline", "واریز به حساب"));

                return paymentModuleItems;
            }

        }

        public static Dictionary<int, Tuple<string, string>> CaseNoteStatusItems
        {
            get
            {
                var CaseNoteStatusItems = new Dictionary<int, Tuple<string, string>>();
                CaseNoteStatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                CaseNoteStatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                return CaseNoteStatusItems;
            }

        }

        public static Dictionary<int, Tuple<string, string>> OrderStatusItems
        {
            get
            {
                var OrderStatusItems = new Dictionary<int, Tuple<string, string>>();
                OrderStatusItems.Add((int) OrderStatusEnum.NotPaid, new Tuple<string, string>("Not Paid", "پرداخت نشده"));
                OrderStatusItems.Add((int) OrderStatusEnum.Pending,
                    new Tuple<string, string>("Pending", "در انتظار تایید"));
                OrderStatusItems.Add((int) OrderStatusEnum.Active, new Tuple<string, string>("Active", "تایید شده"));
                OrderStatusItems.Add((int) OrderStatusEnum.Suspend, new Tuple<string, string>("Suspend", "رد شده"));
                OrderStatusItems.Add((int) OrderStatusEnum.PendingExpire,
                    new Tuple<string, string>("Pending Expire", "در حال انقضا"));
                OrderStatusItems.Add((int) OrderStatusEnum.Expire, new Tuple<string, string>("Expire", "منقضی"));
                OrderStatusItems.Add((int) OrderStatusEnum.Deleted, new Tuple<string, string>("Deleted", "حذف شده"));

                return OrderStatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> DashboardStatusItems
        {
            get
            {
                var DashboardStatusItems = new Dictionary<int, Tuple<string, string>>();
                DashboardStatusItems.Add((int) OrderStatusEnum.NotPaid,
                    new Tuple<string, string>("Not Paid", "پرداخت نشده"));
                DashboardStatusItems.Add((int) OrderStatusEnum.Pending,
                    new Tuple<string, string>("Pending", "در انتظار تایید"));
                DashboardStatusItems.Add((int) OrderStatusEnum.Active, new Tuple<string, string>("Active", "تایید شده"));
                DashboardStatusItems.Add((int) OrderStatusEnum.Suspend, new Tuple<string, string>("Suspend", "رد شده"));
                DashboardStatusItems.Add((int) OrderStatusEnum.PendingExpire,
                    new Tuple<string, string>("Pending Expire", "در حال انقضا"));
                DashboardStatusItems.Add((int) OrderStatusEnum.Expire, new Tuple<string, string>("Expire", "منقضی"));
                DashboardStatusItems.Add((int) OrderStatusEnum.Deleted, new Tuple<string, string>("Deleted", "حذف شده"));

                return DashboardStatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, Tuple<string, string>>> ServiceStatusColors
        {
            get
            {
                var BuiltInItems = new Dictionary<int, Tuple<string, Tuple<string, string>>>();
                BuiltInItems.Add(1,
                    new Tuple<string, Tuple<string, string>>("yellow",
                        new Tuple<string, string>("Not Paid", "پرداخت نشده")));
                BuiltInItems.Add(2,
                    new Tuple<string, Tuple<string, string>>("green",
                        new Tuple<string, string>("Pending", "در انتظار فعال سازی")));
                BuiltInItems.Add(3,
                    new Tuple<string, Tuple<string, string>>("blue", new Tuple<string, string>("Active", "فعال")));
                BuiltInItems.Add(4,
                    new Tuple<string, Tuple<string, string>>("gray", new Tuple<string, string>("Suspend", "غیر فعال")));
                BuiltInItems.Add(5,
                    new Tuple<string, Tuple<string, string>>("brown",
                        new Tuple<string, string>("Pending Expire", "در حال انقضا")));
                BuiltInItems.Add(6,
                    new Tuple<string, Tuple<string, string>>("red", new Tuple<string, string>("Expire", "منقضی")));
                BuiltInItems.Add(7,
                    new Tuple<string, Tuple<string, string>>("purple", new Tuple<string, string>("Deleted", "حذف شده")));
                BuiltInItems.Add(8,
                    new Tuple<string, Tuple<string, string>>("pink",
                        new Tuple<string, string>("Transfering", "در حال انتقال")));
                BuiltInItems.Add(9,
                    new Tuple<string, Tuple<string, string>>("black",
                        new Tuple<string, string>("Acive-Lock", "فعال-قفل")));
                BuiltInItems.Add(10,
                    new Tuple<string, Tuple<string, string>>("black",
                        new Tuple<string, string>("Pending Expire-Lock", "در حال انقضاء-قفل")));
                return BuiltInItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> CaseServiceStatusColors
        {
            get
            {
                var BuiltInItems = new Dictionary<int, Tuple<string, string>>();
                BuiltInItems.Add(1, new Tuple<string, string>("gray", "نامشخص"));
                BuiltInItems.Add(2, new Tuple<string, string>("MediumSeaGreen", "طراحی دارند و راضی هستند"));
                BuiltInItems.Add(3, new Tuple<string, string>("MediumSeaGreen", "طراحی ندارند و راهنمایی شد"));
                BuiltInItems.Add(4, new Tuple<string, string>("Maroon", "نماینده اعتباری"));
                BuiltInItems.Add(5, new Tuple<string, string>("Maroon", "عدم دسترسی"));
                BuiltInItems.Add(6, new Tuple<string, string>("Maroon", "عدم رضایت از پشتیبانی"));
                BuiltInItems.Add(7, new Tuple<string, string>("Maroon", "عدم رضایت از نحوه برخورد"));
                BuiltInItems.Add(8, new Tuple<string, string>("Maroon", "عدم رضایت از میزان منابع"));
                BuiltInItems.Add(9, new Tuple<string, string>("Maroon", "عدم رضایت از سرعت سرور"));
                BuiltInItems.Add(10, new Tuple<string, string>("Maroon", "عدم رضایت از پایداری سرویس"));
                return BuiltInItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> SliderStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> SlideStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> UserProfileStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> AlertJobStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add((int) AlertJobStatusEnum.Sent, new Tuple<string, string>("Sent", "ارسال شده"));
                StatusItems.Add((int) AlertJobStatusEnum.Wait, new Tuple<string, string>("Wait", "در انتظار ارسال"));
                StatusItems.Add((int) AlertJobStatusEnum.Failed, new Tuple<string, string>("Failed", "ارسال نشده"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, string> ActionTypeDictionary
        {
            get
            {
                var actionTypeItems = new Dictionary<int, string>();
                actionTypeItems.Add((int) ActionTypeEnum.Alert, "اطلاع رسانی");
                actionTypeItems.Add((int) ActionTypeEnum.Case, "کیس");
                actionTypeItems.Add((int) ActionTypeEnum.Coupon, "کوپن");
                actionTypeItems.Add((int) ActionTypeEnum.Discount, "تخفیف");
                actionTypeItems.Add((int) ActionTypeEnum.Module, "ماژول");

                return actionTypeItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> EventStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> EventCouponActionSettingItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> EventCaseActionSettingItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> EventDiscountActionSettingItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<byte?, Tuple<string, string>> EventTypeItems
        {
            get
            {
                var TypeItems = new Dictionary<byte?, Tuple<string, string>>();
                TypeItems.Add((int)enumTypeTime.Schedule, new Tuple<string, string>("Schedule", "زمانبندی"));
                TypeItems.Add((int)enumTypeTime.RealTime, new Tuple<string, string>("RealTime", "بلادرنگ"));

                return TypeItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> TemplateStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));
                StatusItems.Add(3, new Tuple<string, string>("Waiting", "منتظر تایید"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> ScaleGroupStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));
                StatusItems.Add(3, new Tuple<string, string>("Waiting", "منتظر تایید"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> ScaleStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));
                StatusItems.Add(3, new Tuple<string, string>("Waiting", "منتظر تایید"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> SettingStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> TemplateStaticStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));
                StatusItems.Add(3, new Tuple<string, string>("Waiting", "منتظر تایید"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> TemplateVariableStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));
                StatusItems.Add(3, new Tuple<string, string>("Waiting", "منتظر تایید"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> AlertTypeStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));
                StatusItems.Add(3, new Tuple<string, string>("Waiting", "منتظر تایید"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }


        public static Dictionary<int, Tuple<string, string>> FactorPaidStatusItems
        {
            get
            {
                var factorPaidPaidItems = new Dictionary<int, Tuple<string, string>>();
                factorPaidPaidItems.Add(1, new Tuple<string, string>("Enable", "پرداخت شده"));
                factorPaidPaidItems.Add(2, new Tuple<string, string>("Disable", "پرداخت نشده"));

                return factorPaidPaidItems;
            }
        }


        public static Dictionary<int, Tuple<string, string>> MessageStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "پاسخ داده شده"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "مشاهده شده"));
                StatusItems.Add(3, new Tuple<string, string>("Waiting", "مشاهده نشده"));
                StatusItems.Add(4, new Tuple<string, string>("Waiting", "پاسخ داده نشده"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));


                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> DomainStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیرفعال"));
                StatusItems.Add(3, new Tuple<string, string>("Waiting", "منتظر تایید"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));


                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> AlertStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> MenuStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> NewsInfoStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> DynamicRouteStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> DiscountStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> DiscountTypeStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> RoleOfUserStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> AmenitiesToProductStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> AmenitiesInGroupStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> ProductClassStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> ProductTypePropertyStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> ProductTypeTaxStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> RoleAccessStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> CityStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> ToDoListStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "انجام شده"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "انجام نشده"));
                return StatusItems;
            }
        }

        public static Dictionary<bool, Tuple<string, string>> ToDoListOperationStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<bool, Tuple<string, string>>();
                StatusItems.Add(true, new Tuple<string, string>("Enable", "خودکار"));
                StatusItems.Add(false, new Tuple<string, string>("Disable", "دستی"));
                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> AmenitiesGroupStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> AmenityStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> BidetStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> ClassStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> CountryStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> PermissionCategoryStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> PermissionStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> ProductStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> FormStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> ProductTypeStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> ProductPropertyStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> PropertyStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> PropertyGroupStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> PropertyTypeStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> ProvinceStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> RoleStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> TaxStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> TimeFrameStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> UserStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> UserTypeStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> WhoisStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));

                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> ProductTypeGroupStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));


                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> EventConditionStatusItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                StatusItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));

                StatusItems.Add((int) BuiltInEntityState.IsDeleted, new Tuple<string, string>("Deleted", "حذف شده ها"));
                StatusItems.Add((int) BuiltInEntityState.IsInTrash, new Tuple<string, string>("Trash", "سطل زباله"));
                StatusItems.Add((int) BuiltInEntityState.IsArcived, new Tuple<string, string>("Archived", "آرشیو"));


                return StatusItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> FinancialStatementStatusItems
        {
            get
            {
                var financialStatementItems = new Dictionary<int, Tuple<string, string>>();
                financialStatementItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                financialStatementItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                return financialStatementItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> FactorStatusItems
        {
            get
            {
                var financialStatementItems = new Dictionary<int, Tuple<string, string>>();
                financialStatementItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                financialStatementItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                return financialStatementItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> OrderDetailStatusItems
        {
            get
            {
                var financialStatementItems = new Dictionary<int, Tuple<string, string>>();
                financialStatementItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                financialStatementItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                return financialStatementItems;
            }
        }

        public static Dictionary<byte, Tuple<string, string>> PaymentStatusItems
        {
            get
            {
                var financialStatementItems = new Dictionary<byte, Tuple<string, string>>();
                financialStatementItems.Add((byte) EnumPaymentStatus.Enable, new Tuple<string, string>("Enable", "فعال"));
                financialStatementItems.Add((byte) EnumPaymentStatus.Disable,
                    new Tuple<string, string>("Disable", "غیر فعال"));
                financialStatementItems.Add((byte) EnumPaymentStatus.SendToBank,
                    new Tuple<string, string>("SendToBank", "ارسال به بانک"));
                financialStatementItems.Add((byte) EnumPaymentStatus.Unallocated,
                    new Tuple<string, string>("Unallocated", "تخصیص نیافته"));
                financialStatementItems.Add((byte) EnumPaymentStatus.PendingApprovalByBank,
                    new Tuple<string, string>("PendingApprovalByBank", "در انتظار تایید از طرف بانک"));
                return financialStatementItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> GroupVariableStatusItems
        {
            get
            {
                var financialStatementItems = new Dictionary<int, Tuple<string, string>>();
                financialStatementItems.Add(1, new Tuple<string, string>("Enable", "فعال"));
                financialStatementItems.Add(2, new Tuple<string, string>("Disable", "غیر فعال"));
                return financialStatementItems;
            }
        }

        #endregion

        #region [ Controller Status ]



        #endregion

        public static Dictionary<int, string> DataType
        {
            get
            {
                var DataTypeItems = new Dictionary<int, string>();
                DataTypeItems.Add(1, "Int");
                DataTypeItems.Add(2, "String");
                DataTypeItems.Add(3, "Float");
                DataTypeItems.Add(4, "Boolean");
                DataTypeItems.Add(5, "Currency");

                return DataTypeItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> UserType
        {
            get
            {
                var DataTypeItems = new Dictionary<int, Tuple<string, string>>();
                DataTypeItems.Add(1, new Tuple<string, string>("Technical", "امور فنی"));
                DataTypeItems.Add(2, new Tuple<string, string>("Billing", "امور مالی"));
                DataTypeItems.Add(3, new Tuple<string, string>("Registration", "امور ثبت"));
                DataTypeItems.Add(4, new Tuple<string, string>("Administrator", "امور مدیریتی"));
                return DataTypeItems;
            }
        }

        public static Dictionary<int, string> AppKeyItems
        {
            get
            {
                var AppKeyItems = new Dictionary<int, string>();
                AppKeyItems.Add(1, "Domain");
                AppKeyItems.Add(2, "WebHost");
                AppKeyItems.Add(3, "DedicateServer");
                AppKeyItems.Add(4, "Email");
                AppKeyItems.Add(5, "PrivateHost");
                AppKeyItems.Add(6, "PrivateReseller");
                AppKeyItems.Add(7, "AffiliateReseller");
                AppKeyItems.Add(8, "FireWall");
                AppKeyItems.Add(9, "BackUpService");
                AppKeyItems.Add(10, "MonitoringService");
                return AppKeyItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> SettingValueKeyItems
        {
            get
            {
                var StatusItems = new Dictionary<int, Tuple<string, string>>();
                StatusItems.Add(1, new Tuple<string, string>("Thumbnail", "اندازه thumbnail"));
                StatusItems.Add(2, new Tuple<string, string>("TimeFrame", "اندازه بازه زمانی"));
                return StatusItems;
            }
        }

        public static Dictionary<short, Tuple<string, string>> CaseTypeItems
        {
            get
            {
                var CaseTypeItems = new Dictionary<short, Tuple<string, string>>();
                CaseTypeItems.Add((short) CaseTypeEnum.Renewed, new Tuple<string, string>("Renewed", "تمدید"));
                CaseTypeItems.Add((short) CaseTypeEnum.NewOrder, new Tuple<string, string>("NewOrder", "سفارش جدید"));
                CaseTypeItems.Add((short) CaseTypeEnum.SatisfactionAfterRenewed,
                    new Tuple<string, string>("SatisfactionAfterRenewed", "رضایت پس از تمدید"));
                CaseTypeItems.Add((short) CaseTypeEnum.SatisfactionAfterSale,
                    new Tuple<string, string>("SatisfactionAfterSale", "رضایت پس از فروش"));
                return CaseTypeItems;

            }
        }

        public static Dictionary<string, string> TemplateVariableItemsKey
        {
            get
            {
                var AppKeyItems = new Dictionary<string, string>();
                AppKeyItems.Add("@@UserName", "نام کاربری");
                AppKeyItems.Add("@@Price", "قیمت");
                return AppKeyItems;
            }
        }

        public static List<string> IconClass
        {
            get
            {
                var ClassItems = new List<string>();
                ClassItems.Add("icon-compass");
                ClassItems.Add("icon-eur");
                ClassItems.Add("icon-dollar");
                ClassItems.Add("icon-yen");
                ClassItems.Add("icon-won");
                ClassItems.Add("icon-file-text");
                ClassItems.Add("icon-sort-by-attributes-alt");
                ClassItems.Add("icon-thumbs-down");
                ClassItems.Add("icon-xing-sign");
                ClassItems.Add("icon-instagram");
                ClassItems.Add("icon-bitbucket-sign");
                ClassItems.Add("icon-long-arrow-up");
                ClassItems.Add("icon-windows");
                ClassItems.Add("icon-skype");
                ClassItems.Add("icon-male");
                ClassItems.Add("icon-archive");
                ClassItems.Add("icon-renren");
                ClassItems.Add("icon-collapse");
                ClassItems.Add("icon-euro");
                ClassItems.Add("icon-inr");
                ClassItems.Add("icon-cny");
                ClassItems.Add("icon-btc");
                ClassItems.Add("icon-sort-by-alphabet");
                ClassItems.Add("icon-sort-by-order");
                ClassItems.Add("icon-youtube-sign");
                ClassItems.Add("icon-youtube-play");
                ClassItems.Add("icon-flickr");
                ClassItems.Add("icon-tumblr");
                ClassItems.Add("icon-long-arrow-left");
                ClassItems.Add("icon-android");
                ClassItems.Add("icon-foursquare");
                ClassItems.Add("icon-gittip");
                ClassItems.Add("icon-bug");
                ClassItems.Add("icon-collapse-top");
                ClassItems.Add("icon-gbp");
                ClassItems.Add("icon-rupee");
                ClassItems.Add("icon-renminbi");
                ClassItems.Add("icon-bitcoin");
                ClassItems.Add("icon-sort-by-alphabet-alt");
                ClassItems.Add("icon-sort-by-order-alt");
                ClassItems.Add("icon-youtube");
                ClassItems.Add("icon-dropbox");
                ClassItems.Add("icon-adn");
                ClassItems.Add("icon-tumblr-sign");
                ClassItems.Add("icon-long-arrow-right");
                ClassItems.Add("icon-linux");
                ClassItems.Add("icon-trello");
                ClassItems.Add("icon-sun");
                ClassItems.Add("icon-vk");
                ClassItems.Add("icon-expand");
                ClassItems.Add("icon-usd");
                ClassItems.Add("icon-jpy");
                ClassItems.Add("icon-krw");
                ClassItems.Add("icon-file");
                ClassItems.Add("icon-sort-by-attributes");
                ClassItems.Add("icon-thumbs-up");
                ClassItems.Add("icon-xing");
                ClassItems.Add("icon-stackexchange");
                ClassItems.Add("icon-bitbucket");
                ClassItems.Add("icon-long-arrow-down");
                ClassItems.Add("icon-apple");
                ClassItems.Add("icon-dribble");
                ClassItems.Add("icon-female");
                ClassItems.Add("icon-moon");
                ClassItems.Add("icon-weibo");
                ClassItems.Add("icon-adjust");
                ClassItems.Add("icon-asterisk");
                ClassItems.Add("icon-ban-circle");
                ClassItems.Add("icon-bar-chart");
                ClassItems.Add("icon-barcode");
                ClassItems.Add("icon-beaker");
                ClassItems.Add("icon-bell");
                ClassItems.Add("icon-bolt");
                ClassItems.Add("icon-book");
                ClassItems.Add("icon-bookmark");
                ClassItems.Add("icon-bookmark-empty");
                ClassItems.Add("icon-briefcase");
                ClassItems.Add("icon-bullhorn");
                ClassItems.Add("icon-calendar");
                ClassItems.Add("icon-camera");
                ClassItems.Add("icon-camera-retro");
                ClassItems.Add("icon-certificate");
                ClassItems.Add("icon-check");
                ClassItems.Add("icon-check-empty");
                ClassItems.Add("icon-cloud");
                ClassItems.Add("icon-cog");
                ClassItems.Add("icon-cogs");
                ClassItems.Add("icon-comment");
                ClassItems.Add("icon-comment-alt");
                ClassItems.Add("icon-comments");
                ClassItems.Add("icon-comments-alt");
                ClassItems.Add("icon-credit-card");
                ClassItems.Add("icon-dashboard");
                ClassItems.Add("icon-download");
                ClassItems.Add("icon-download-alt");
                ClassItems.Add("icon-edit");
                ClassItems.Add("icon-envelope");
                ClassItems.Add("icon-envelope-alt");
                ClassItems.Add("icon-exclamation-sign");
                ClassItems.Add("icon-external-link");
                ClassItems.Add("icon-eye-close");
                ClassItems.Add("icon-eye-open");
                ClassItems.Add("icon-facetime-video");
                ClassItems.Add("icon-film");
                ClassItems.Add("icon-filter");
                ClassItems.Add("icon-fire");
                ClassItems.Add("icon-flag");
                ClassItems.Add("icon-folder-close");
                ClassItems.Add("icon-folder-open");
                ClassItems.Add("icon-gift");
                ClassItems.Add("icon-glass");
                ClassItems.Add("icon-globe");
                ClassItems.Add("icon-group");
                ClassItems.Add("icon-hdd");
                ClassItems.Add("icon-headphones");
                ClassItems.Add("icon-heart");
                ClassItems.Add("icon-heart-empty");
                ClassItems.Add("icon-home");
                ClassItems.Add("icon-inbox");
                ClassItems.Add("icon-info-sign");
                ClassItems.Add("icon-key");
                ClassItems.Add("icon-leaf");
                ClassItems.Add("icon-legal");
                ClassItems.Add("icon-lemon");
                ClassItems.Add("icon-lock");
                ClassItems.Add("icon-unlock");
                ClassItems.Add("icon-magic");
                ClassItems.Add("icon-magnet");
                ClassItems.Add("icon-map-marker");
                ClassItems.Add("icon-minus");
                ClassItems.Add("icon-minus-sign");
                ClassItems.Add("icon-money");
                ClassItems.Add("icon-move");
                ClassItems.Add("icon-music");
                ClassItems.Add("icon-off");
                ClassItems.Add("icon-ok");
                ClassItems.Add("icon-ok-circle");
                ClassItems.Add("icon-ok-sign");
                ClassItems.Add("icon-pencil");
                ClassItems.Add("icon-picture");
                ClassItems.Add("icon-plane");
                ClassItems.Add("icon-plus");
                ClassItems.Add("icon-plus-sign");
                ClassItems.Add("icon-print");
                ClassItems.Add("icon-pushpin");
                ClassItems.Add("icon-qrcode");
                ClassItems.Add("icon-question-sign");
                ClassItems.Add("icon-random");
                ClassItems.Add("icon-refresh");
                ClassItems.Add("icon-remove");
                ClassItems.Add("icon-remove-circle");
                ClassItems.Add("icon-remove-sign");
                ClassItems.Add("icon-reorder");
                ClassItems.Add("icon-resize-horizontal");
                ClassItems.Add("icon-resize-vertical");
                ClassItems.Add("icon-retweet");
                ClassItems.Add("icon-road");
                ClassItems.Add("icon-rss");
                ClassItems.Add("icon-screenshot");
                ClassItems.Add("icon-search");
                ClassItems.Add("icon-share");
                ClassItems.Add("icon-share-alt");
                ClassItems.Add("icon-shopping-cart");
                ClassItems.Add("icon-signal");
                ClassItems.Add("icon-signin");
                ClassItems.Add("icon-signout");
                ClassItems.Add("icon-sitemap");
                ClassItems.Add("icon-sort");
                ClassItems.Add("icon-sort-down");
                ClassItems.Add("icon-sort-up");
                ClassItems.Add("icon-star");
                ClassItems.Add("icon-star-empty");
                ClassItems.Add("icon-star-half");
                ClassItems.Add("icon-tag");
                ClassItems.Add("icon-tags");
                ClassItems.Add("icon-tasks");
                ClassItems.Add("icon-thumbs-down");
                ClassItems.Add("icon-thumbs-up");
                ClassItems.Add("icon-time");
                ClassItems.Add("icon-tint");
                ClassItems.Add("icon-trash");
                ClassItems.Add("icon-trophy");
                ClassItems.Add("icon-truck");
                ClassItems.Add("icon-umbrella");
                ClassItems.Add("icon-upload");
                ClassItems.Add("icon-upload-alt");
                ClassItems.Add("icon-user");
                ClassItems.Add("icon-user-md");
                ClassItems.Add("icon-volume-off");
                ClassItems.Add("icon-volume-down");
                ClassItems.Add("icon-volume-up");
                ClassItems.Add("icon-warning-sign");
                ClassItems.Add("icon-wrench");
                ClassItems.Add("icon-zoom-in");
                ClassItems.Add("icon-zoom-out");
                ClassItems.Add("icon-bitcoin");
                ClassItems.Add("icon-eur");
                ClassItems.Add("icon-jpy");
                ClassItems.Add("icon-usd");
                ClassItems.Add("icon-btc");
                ClassItems.Add("icon-euro");
                ClassItems.Add("icon-krw");
                ClassItems.Add("icon-won");
                ClassItems.Add("icon-cny");
                ClassItems.Add("icon-gbp");
                ClassItems.Add("icon-renminbi");
                ClassItems.Add("icon-yen");
                ClassItems.Add("icon-dollar");
                ClassItems.Add("icon-inr");
                ClassItems.Add("icon-rupee");
                ClassItems.Add("icon-file");
                ClassItems.Add("icon-cut");
                ClassItems.Add("icon-copy");
                ClassItems.Add("icon-paste");
                ClassItems.Add("icon-save");
                ClassItems.Add("icon-undo");
                ClassItems.Add("icon-repeat");
                ClassItems.Add("icon-paper-clip");
                ClassItems.Add("icon-text-height");
                ClassItems.Add("icon-text-width");
                ClassItems.Add("icon-align-left");
                ClassItems.Add("icon-align-center");
                ClassItems.Add("icon-align-right");
                ClassItems.Add("icon-align-justify");
                ClassItems.Add("icon-indent-left");
                ClassItems.Add("icon-indent-right");
                ClassItems.Add("icon-font");
                ClassItems.Add("icon-bold");
                ClassItems.Add("icon-italic");
                ClassItems.Add("icon-strikethrough");
                ClassItems.Add("icon-underline");
                ClassItems.Add("icon-link");
                ClassItems.Add("icon-columns");
                ClassItems.Add("icon-table");
                ClassItems.Add("icon-th-large");
                ClassItems.Add("icon-th");
                ClassItems.Add("icon-th-list");
                ClassItems.Add("icon-list");
                ClassItems.Add("icon-list-ol");
                ClassItems.Add("icon-list-ul");
                ClassItems.Add("icon-list-alt");
                ClassItems.Add("icon-arrow-down");
                ClassItems.Add("icon-arrow-left");
                ClassItems.Add("icon-arrow-right");
                ClassItems.Add("icon-arrow-up");
                ClassItems.Add("icon-chevron-down");
                ClassItems.Add("icon-circle-arrow-down");
                ClassItems.Add("icon-circle-arrow-left");
                ClassItems.Add("icon-circle-arrow-right");
                ClassItems.Add("icon-circle-arrow-up");
                ClassItems.Add("icon-chevron-left");
                ClassItems.Add("icon-caret-down");
                ClassItems.Add("icon-caret-left");
                ClassItems.Add("icon-caret-right");
                ClassItems.Add("icon-caret-up");
                ClassItems.Add("icon-chevron-right");
                ClassItems.Add("icon-hand-down");
                ClassItems.Add("icon-hand-left");
                ClassItems.Add("icon-hand-right");
                ClassItems.Add("icon-hand-up");
                ClassItems.Add("icon-chevron-up");
                ClassItems.Add("icon-play-circle");
                ClassItems.Add("icon-play");
                ClassItems.Add("icon-pause");
                ClassItems.Add("icon-stop");
                ClassItems.Add("icon-step-backward");
                ClassItems.Add("icon-fast-backward");
                ClassItems.Add("icon-backward");
                ClassItems.Add("icon-forward");
                ClassItems.Add("icon-fast-forward");
                ClassItems.Add("icon-step-forward");
                ClassItems.Add("icon-eject");
                ClassItems.Add("icon-fullscreen");
                ClassItems.Add("icon-resize-full");
                ClassItems.Add("icon-resize-small");
                ClassItems.Add("icon-adn");
                ClassItems.Add("icon-bitbucket-sign");
                ClassItems.Add("icon-dribble");
                ClassItems.Add("icon-flickr");
                ClassItems.Add("icon-github-sign");
                ClassItems.Add("icon-html5");
                ClassItems.Add("icon-linux");
                ClassItems.Add("icon-renren");
                ClassItems.Add("icon-tumblr");
                ClassItems.Add("icon-vk");
                ClassItems.Add("icon-xing-sign");
                ClassItems.Add("icon-android");
                ClassItems.Add("icon-bitcoin");
                ClassItems.Add("icon-dropbox");
                ClassItems.Add("icon-foursquare");
                ClassItems.Add("icon-gittip");
                ClassItems.Add("icon-instagram");
                ClassItems.Add("icon-maxcdn");
                ClassItems.Add("icon-skype");
                ClassItems.Add("icon-tumblr-sign");
                ClassItems.Add("icon-weibo");
                ClassItems.Add("icon-youtube");
                ClassItems.Add("icon-apple");
                ClassItems.Add("icon-facebook");
                ClassItems.Add("icon-github");
                ClassItems.Add("icon-google-plus");
                ClassItems.Add("icon-linkedin");
                ClassItems.Add("icon-pinterest");
                ClassItems.Add("icon-stackexchange");
                ClassItems.Add("icon-twitter");
                ClassItems.Add("icon-windows");
                ClassItems.Add("icon-youtube-play");
                ClassItems.Add("icon-bitbucket");
                ClassItems.Add("icon-css3");
                ClassItems.Add("icon-facebook-sign");
                ClassItems.Add("icon-github-alt");
                ClassItems.Add("icon-google-plus-sign");
                ClassItems.Add("icon-linkedin-sign");
                ClassItems.Add("icon-pinterest-sign");
                ClassItems.Add("icon-trello");
                ClassItems.Add("icon-twitter-sign");
                ClassItems.Add("icon-xing");
                ClassItems.Add("icon-youtube-sign");
                ClassItems.Add("icon-ambulance");
                ClassItems.Add("icon-plus-sign-alt");
                ClassItems.Add("icon-h-sign");
                ClassItems.Add("icon-stethoscope");
                ClassItems.Add("icon-hospital");
                ClassItems.Add("icon-user-md");
                ClassItems.Add("icon-medkit");
                return ClassItems;
            }
        }

        /// <summary>
        ///  انواع موارد استفاده از تخفیف
        /// </summary>
        public static Dictionary<int, Tuple<string, string>> UsesDiscountItems
        {
            get
            {
                var UsesDiscountItems = new Dictionary<int, Tuple<string, string>>();
                UsesDiscountItems.Add((int) ERP.UI.Web.UsesDiscountEnum.ProductTypeGroup,
                    new Tuple<string, string>("ProductTypeGroup", "گروه نوع محصول"));
                UsesDiscountItems.Add((int) ERP.UI.Web.UsesDiscountEnum.ProductType,
                    new Tuple<string, string>("ProductType", "نوع محصول"));
                UsesDiscountItems.Add((int) ERP.UI.Web.UsesDiscountEnum.Product,
                    new Tuple<string, string>("Product", "محصول"));
                UsesDiscountItems.Add((int) ERP.UI.Web.UsesDiscountEnum.Event,
                    new Tuple<string, string>("Event", "رویداد"));
                return UsesDiscountItems;
            }
        }

        public static Dictionary<int, Tuple<string, string>> Gender
        {
            get
            {
                return new Dictionary<int, Tuple<string, string>>
                {
                    {1, new Tuple<string, string>("Man", "مرد")},
                    {2, new Tuple<string, string>("Woman", "زن")}
                };
            }
        }

        /// <summary>
        ///  انواع نوع منو
        /// </summary>
        public static Dictionary<int, Tuple<string, string>> TypesItems
        {
            get
            {
                var TypesItems = new Dictionary<int, Tuple<string, string>>();

                TypesItems.Add((int) MenuType.ExternalLink, new Tuple<string, string>("ExternalLink", "لینک خارجی"));
                TypesItems.Add((int) MenuType.InternalDynamicLink,
                    new Tuple<string, string>("InternalDynamicLink", "لینک داخلی پویا"));
                TypesItems.Add((int) MenuType.InternalStaticLink,
                    new Tuple<string, string>("InternalStaticLink", "لینک داخلی ثابت"));

                return TypesItems;
            }
        }


        /// <summary>
        ///انواع نحوه نمایش منو
        /// </summary>
        public static Dictionary<int, Tuple<string, string>> ViewTypeItems
        {
            get
            {
                var ViewTypeItems = new Dictionary<int, Tuple<string, string>>();
                ViewTypeItems.Add((int) MenuViewType.Accordion, new Tuple<string, string>("Accardion", "Accardion"));
                ViewTypeItems.Add((int) MenuViewType.FullWidth, new Tuple<string, string>("FullWidth", "FullWidth"));
                ViewTypeItems.Add((int) MenuViewType.Normal, new Tuple<string, string>("Normal", "Normal"));
                return ViewTypeItems;
            }
        }


        public static Dictionary<int, string> AreaTypeItems
        {
            get
            {
                var AreaTypeItems = new Dictionary<int, string>();

                AreaTypeItems.Add((int) Area.Admin, "Admin");
                AreaTypeItems.Add((int) Area.Client, "Client");
                AreaTypeItems.Add((int) Area.FrontEnd, "FrontEnd");

                return AreaTypeItems;
            }
        }

        public static Dictionary<int, string> TargetTypeItems
        {
            get
            {
                var targetTypeItems = new Dictionary<int, string>();
                targetTypeItems.Add((int) TargetType._blank, "_blank");
                targetTypeItems.Add((int) TargetType._parent, "_parent");
                targetTypeItems.Add((int) TargetType._self, "_self");
                targetTypeItems.Add((int) TargetType._top, "_top");

                return targetTypeItems;
            }
        }

        public static Dictionary<int, string> DataTransition
        {
            get
            {
                var DataTypeItems = new Dictionary<int, string>();
                DataTypeItems.Add(1, "fade");
                DataTypeItems.Add(2, "flip");
                DataTypeItems.Add(3, "flow");
                DataTypeItems.Add(4, "pop");
                DataTypeItems.Add(5, "slide");
                DataTypeItems.Add(6, "slidefade");
                DataTypeItems.Add(7, "slideup");
                DataTypeItems.Add(8, "slidedown");
                DataTypeItems.Add(9, "turn");
                DataTypeItems.Add(10, "none");

                return DataTypeItems;
            }
        }







        // YB
        public static Dictionary<string, string> dictionaryWhereClauseField
        {
            get
            {
                var whereClauseFieldItems = new Dictionary<string, string>();
                whereClauseFieldItems.Add("UserProfile", "fk_UserID");
                whereClauseFieldItems.Add("Service", "fk_OrderDetailID");
                whereClauseFieldItems.Add("DomainNameServer", "fk_ModuleID");
                //whereClauseFieldItems.Add("DomainNameServer", "fk_ProductTypeID");
                //whereClauseFieldItems.Add("DomainNameServer", "fk_UserID");


                return whereClauseFieldItems;
            }
        }

        public static Dictionary<enumModules, string> dictionaryModules
        {
            get
            {
                var dict = new Dictionary<enumModules, string>();
                dict.Add(enumModules.NicModule, "ERP.Modules.Registrar.Nic.NicModule");
                dict.Add(enumModules.ReselloModule, "ERP.Modules.Registrar.Resello.ReselloModule");
                dict.Add(enumModules.DirectI, "ERP.Modules.Registrar.DirectI");
                dict.Add(enumModules.OnlineNicModule, "ERP.Modules.Registrar.OnlineNic.OnlineNicModule");
                dict.Add(enumModules.PasargadModule, "ERP.Modules.Payment.Pasargad.PasargadModule");
                dict.Add(enumModules.MellatModule, "ERP.Modules.Payment.Mellat.MellatModule");
                dict.Add(enumModules.SamanModule, "ERP.Modules.Payment.Saman.SamanModule");
                dict.Add(enumModules.ParsianModule, "ERP.Modules.Payment.Parsian.ParsianModule");
                dict.Add(enumModules.OfflineModule, "ERP.Modules.Payment.Offline.OfflineModule");
                dict.Add(enumModules.SMSModule, "ERP.Modules.Communication.SMS.SMSModule");
                dict.Add(enumModules.MailModule, "ERP.Modules.Communication.Mail.MailModule");
                dict.Add(enumModules.FaxModule, "ERP.Modules.Communication.Fax.FaxModule");

                return dict;
            }
        }

        //SM
        public static Dictionary<int, Tuple<string, string>> AccessType
        {
            get
            {
                var AccessTypeItems = new Dictionary<int, Tuple<string, string>>();
                AccessTypeItems.Add(1, new Tuple<string, string>("Allow", "مجاز"));
                AccessTypeItems.Add(2, new Tuple<string, string>("Deny", "مسدود"));
                AccessTypeItems.Add(3, new Tuple<string, string>("Neutral", "خنثی"));
                AccessTypeItems.Add(4, new Tuple<string, string>("AllowWithDelegation", "مجاز همراه با تفویض اختیار"));
                AccessTypeItems.Add(5, new Tuple<string, string>("NotAllow", "غیر مجاز"));
                return AccessTypeItems;
            }
        }
        // SM
        public static Dictionary<int, Tuple<string, string>> ProductTypeCopyDictionary
        {
            get
            {
                var BuiltInItems = new Dictionary<int, Tuple<string, string>>();
                BuiltInItems.Add(1, new Tuple<string, string>("Add", "افزودن حروف"));
                BuiltInItems.Add(2, new Tuple<string, string>("Delete", "حذف حروف"));
                BuiltInItems.Add(3, new Tuple<string, string>("Replace", "جایگزینی حروف"));
                return BuiltInItems;
            }
        }
        // SM
        public static Dictionary<int, Tuple<string, string>> OperationTypeDictionary
        {
            get
            {
                var BuiltInItems = new Dictionary<int, Tuple<string, string>>();
                BuiltInItems.Add(0, new Tuple<string, string>("RegisterDomain", "ثبت دامین"));
                BuiltInItems.Add(1, new Tuple<string, string>("TransferDomain", "انتقال دامین"));
                BuiltInItems.Add(2, new Tuple<string, string>("RenewDomain", "تمدید دامین"));
                BuiltInItems.Add(3, new Tuple<string, string>("ChangeDns", "تغییر دی ان اس"));
                return BuiltInItems;
            }
        }
    }
}