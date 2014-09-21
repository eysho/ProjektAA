using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoExp.Quests;

namespace AutoExp.Modules
{
    internal class QuestModule : Module
    {
        private List<Quest> questsCanBeRun;

        public override void Start(Host host)
        {
            base.Start(host);
            questsCanBeRun = new List<Quest>();
            #region Falcorth Plains
            questsCanBeRun.Add(new Quest_1212(1, 15, QuestRace.Ferre, new uint[] { }));
            questsCanBeRun.Add(new Quest_1213(1, 15, QuestRace.Ferre, new uint[] { 1212 }));
            questsCanBeRun.Add(new Quest_1573(1, 15, QuestRace.Ferre, new uint[] { 1213 }));
            questsCanBeRun.Add(new Quest_1218(1, 15, QuestRace.Ferre, new uint[] { 1573 }));
            questsCanBeRun.Add(new Quest_1574(1, 15, QuestRace.Ferre, new uint[] { 1573 }));
            questsCanBeRun.Add(new Quest_4477(1, 15, QuestRace.Ferre, new uint[] { 1218 }));
            questsCanBeRun.Add(new Quest_953(1, 15, QuestRace.Ferre, new uint[] { 4477 }));
            questsCanBeRun.Add(new Quest_1215(1, 15, QuestRace.Ferre, new uint[] { 4477 }));
            questsCanBeRun.Add(new Quest_1216(1, 15, QuestRace.Ferre, new uint[] { 1215 }));
            questsCanBeRun.Add(new Quest_1222(1, 15, QuestRace.Ferre, new uint[] { 1574 }));
            questsCanBeRun.Add(new Quest_2300(1, 15, QuestRace.Ferre, new uint[] { 1222 }));
            questsCanBeRun.Add(new Quest_4289(1, 15, QuestRace.Ferre, new uint[] { 1222 }, new uint[] { 1644 }));     //daily
            questsCanBeRun.Add(new Quest_3435(1, 15, QuestRace.Ferre, new uint[] { 1216 }));
            questsCanBeRun.Add(new Quest_3436(1, 15, QuestRace.Ferre, new uint[] { 3435 }));
            questsCanBeRun.Add(new Quest_3437(1, 15, QuestRace.Ferre, new uint[] { 3436 }));
            questsCanBeRun.Add(new Quest_2309(1, 15, QuestRace.Ferre, new uint[] { 3437 }));
            questsCanBeRun.Add(new Quest_1233(1, 15, QuestRace.Ferre, new uint[] { 3437 }));
            questsCanBeRun.Add(new Quest_1644(1, 15, QuestRace.Ferre, new uint[] { 1233 }));
            questsCanBeRun.Add(new Quest_2538(1, 15, QuestRace.Ferre, new uint[] { 1644 }));
            questsCanBeRun.Add(new Quest_1234(1, 15, QuestRace.Ferre, new uint[] { 2538 }));
            questsCanBeRun.Add(new Quest_2315(1, 15, QuestRace.Ferre, new uint[] { 2309 }));
            questsCanBeRun.Add(new Quest_1570(1, 15, QuestRace.Ferre, new uint[] { 2309 }));
            questsCanBeRun.Add(new Quest_1301(1, 15, QuestRace.Ferre, new uint[] { 2309 }));
            questsCanBeRun.Add(new Quest_1240(1, 15, QuestRace.Ferre, new uint[] { 1301 }));
            questsCanBeRun.Add(new Quest_1241(1, 15, QuestRace.Ferre, new uint[] { 1301 }, new uint[] { 1239 }));       //daily
            questsCanBeRun.Add(new Quest_3438(1, 15, QuestRace.Ferre, new uint[] { 1570 }));
            questsCanBeRun.Add(new Quest_1236(1, 15, QuestRace.Ferre, new uint[] { 1570 }));
            questsCanBeRun.Add(new Quest_1571(1, 15, QuestRace.Ferre, new uint[] { 1236 }));
            questsCanBeRun.Add(new Quest_1239(1, 15, QuestRace.Ferre, new uint[] { 1571 }));
            questsCanBeRun.Add(new Quest_3439(1, 15, QuestRace.Ferre, new uint[] { 1239 }));
            questsCanBeRun.Add(new Quest_1696(1, 15, QuestRace.Ferre, new uint[] { 3439 }));
            questsCanBeRun.Add(new Quest_3440(1, 15, QuestRace.Ferre, new uint[] { 3439 }));
            questsCanBeRun.Add(new Quest_1565(1, 15, QuestRace.Ferre, new uint[] { 3439 }));
            questsCanBeRun.Add(new Quest_2764(1, 15, QuestRace.Ferre, new uint[] { 3439, 1565 }));
            questsCanBeRun.Add(new Quest_1363(1, 15, QuestRace.Ferre, new uint[] { 2764, 1565 }));
            questsCanBeRun.Add(new Quest_1364(1, 15, QuestRace.Ferre, new uint[] { 1363 }));
            questsCanBeRun.Add(new Quest_1417(1, 15, QuestRace.Ferre, new uint[] { 1364 }));
            questsCanBeRun.Add(new Quest_1366(1, 15, QuestRace.Ferre, new uint[] { 1417, 3440 }));
            questsCanBeRun.Add(new Quest_1367(1, 15, QuestRace.Ferre, new uint[] { 1417 }));
            questsCanBeRun.Add(new Quest_1365(1, 15, QuestRace.Ferre, new uint[] { 1417 }));
            questsCanBeRun.Add(new Quest_1413(1, 15, QuestRace.Ferre, new uint[] { 1417 }));
            questsCanBeRun.Add(new Quest_6352(1, 15, QuestRace.Ferre, new uint[] { 1366, 1367, 1365 }));
            questsCanBeRun.Add(new Quest_1369(1, 15, QuestRace.Ferre, new uint[] { 1366, 1367, 1365 }));
            questsCanBeRun.Add(new Quest_1407(1, 15, QuestRace.Ferre, new uint[] { 1369 }));
            questsCanBeRun.Add(new Quest_2326(1, 15, QuestRace.Ferre, new uint[] { 4302 }));
            questsCanBeRun.Add(new Quest_2517(1, 15, QuestRace.Ferre, new uint[] { 4302 }));
            questsCanBeRun.Add(new Quest_4296(1, 15, QuestRace.Ferre, new uint[] { 1407, 3440, 6352 }));
            questsCanBeRun.Add(new Quest_4301(1, 15, QuestRace.Ferre, new uint[] { 4296 }));
            questsCanBeRun.Add(new Quest_4302(1, 15, QuestRace.Ferre, new uint[] { 4301 }));
            questsCanBeRun.Add(new Quest_2533(1, 15, QuestRace.Ferre, new uint[] { 2517 }));
            questsCanBeRun.Add(new Quest_1438(1, 15, QuestRace.Ferre, new uint[] { 2533 }));
            questsCanBeRun.Add(new Quest_2328(1, 15, QuestRace.Ferre, new uint[] { 2533, 2326 }));
            questsCanBeRun.Add(new Quest_1439(1, 15, QuestRace.Ferre, new uint[] { 1438, 2328 }));
            questsCanBeRun.Add(new Quest_1237(1, 15, QuestRace.Ferre, new uint[] { 1439 }));
            questsCanBeRun.Add(new Quest_3442(1, 15, QuestRace.Ferre, new uint[] { 1439 }));
            questsCanBeRun.Add(new Quest_1440(1, 15, QuestRace.Ferre, new uint[] { 1439 }, new uint[] { 1433 }));        //daily
            questsCanBeRun.Add(new Quest_2535(1, 15, QuestRace.Ferre, new uint[] { 1237 }));
            questsCanBeRun.Add(new Quest_3443(1, 15, QuestRace.Ferre, new uint[] { 3442 }));
            questsCanBeRun.Add(new Quest_2537(1, 15, QuestRace.Ferre, new uint[] { 3444 }));
            questsCanBeRun.Add(new Quest_3444(1, 15, QuestRace.Ferre, new uint[] { 2535, 3443 }));
            questsCanBeRun.Add(new Quest_3445(1, 15, QuestRace.Ferre, new uint[] { 3444 }));
            questsCanBeRun.Add(new Quest_6353(1, 15, QuestRace.Ferre, new uint[] { 2537 }));
            questsCanBeRun.Add(new Quest_1433(1, 15, QuestRace.Ferre, new uint[] { 2537 }));
            questsCanBeRun.Add(new Quest_1436(1, 15, QuestRace.Ferre, new uint[] { 2537 }, new uint[] { 1437 }));        //daily
            questsCanBeRun.Add(new Quest_5145(1, 15, QuestRace.Ferre, new uint[] { 1433, 6353 }));
            questsCanBeRun.Add(new Quest_1441(1, 15, QuestRace.Ferre, new uint[] { 1433, 6353 }));
            questsCanBeRun.Add(new Quest_1437(1, 15, QuestRace.Ferre, new uint[] { 1433, 6353 }));
            #endregion
            #region Tigerspine Mountains
            questsCanBeRun.Add(new Quest_1048(8, 17, QuestRace.Ferre, new uint[] { 1441, 1437 }));
            questsCanBeRun.Add(new Quest_1476(8, 17, QuestRace.Ferre, new uint[] { 1048 }));
            questsCanBeRun.Add(new Quest_1254(8, 17, QuestRace.Ferre, new uint[] { 3445 }));
            questsCanBeRun.Add(new Quest_1257(8, 17, QuestRace.Ferre, new uint[] { 1254 }));
            questsCanBeRun.Add(new Quest_1572(8, 17, QuestRace.Ferre, new uint[] { 1257 }));
            questsCanBeRun.Add(new Quest_4862(8, 17, QuestRace.Ferre, new uint[] { 1257 }));
            questsCanBeRun.Add(new Quest_4415(8, 17, QuestRace.Ferre, new uint[] { 5145 }));
            questsCanBeRun.Add(new Quest_4479(8, 17, QuestRace.Ferre, new uint[] { 4415 }));
            questsCanBeRun.Add(new Quest_4417(8, 17, QuestRace.Ferre, new uint[] { 4479 }));
            questsCanBeRun.Add(new Quest_4424(8, 17, QuestRace.Ferre, new uint[] { 4417 }));
            questsCanBeRun.Add(new Quest_4439(8, 17, QuestRace.Ferre, new uint[] { 4424 }));
            questsCanBeRun.Add(new Quest_4438(8, 17, QuestRace.Ferre, new uint[] { 4439 }));
            questsCanBeRun.Add(new Quest_1049(8, 17, QuestRace.Ferre, new uint[] { 1476 }));
            questsCanBeRun.Add(new Quest_1050(8, 17, QuestRace.Ferre, new uint[] { 1049 }));
            questsCanBeRun.Add(new Quest_1084(8, 17, QuestRace.Ferre, new uint[] { 1050 }));
            questsCanBeRun.Add(new Quest_1051(8, 17, QuestRace.Ferre, new uint[] { 1084 }));
            questsCanBeRun.Add(new Quest_1052(8, 17, QuestRace.Ferre, new uint[] { 1051 }));
            questsCanBeRun.Add(new Quest_1059(8, 17, QuestRace.Ferre, new uint[] { 1052 }));
            questsCanBeRun.Add(new Quest_1060(8, 17, QuestRace.Ferre, new uint[] { 1059 }));
            questsCanBeRun.Add(new Quest_1053(8, 17, QuestRace.Ferre, new uint[] { 1060 }));
            questsCanBeRun.Add(new Quest_3446(8, 17, QuestRace.Ferre, new uint[] { 1572 }));
            questsCanBeRun.Add(new Quest_1054(8, 17, QuestRace.Ferre, new uint[] { 1572 }));
            questsCanBeRun.Add(new Quest_1058(8, 17, QuestRace.Ferre, new uint[] { 1572 }, new uint[] { 1061 }));       //daily
            questsCanBeRun.Add(new Quest_1061(8, 17, QuestRace.Ferre, new uint[] { 1054 }));
            questsCanBeRun.Add(new Quest_1064(8, 17, QuestRace.Ferre, new uint[] { 1061 }));
            questsCanBeRun.Add(new Quest_1062(8, 17, QuestRace.Ferre, new uint[] { 1061 }));
            questsCanBeRun.Add(new Quest_1055(8, 17, QuestRace.Ferre, new uint[] { 1061 }, new uint[] { 1065 }));       //daily
            questsCanBeRun.Add(new Quest_1065(8, 17, QuestRace.Ferre, new uint[] { 1064 }));
            questsCanBeRun.Add(new Quest_1066(8, 17, QuestRace.Ferre, new uint[] { 1065 }));
            questsCanBeRun.Add(new Quest_6031(8, 17, QuestRace.Ferre, new uint[] { 1066, 1062 }, new uint[] { 1071 }));
            questsCanBeRun.Add(new Quest_1068(8, 17, QuestRace.Ferre, new uint[] { 1066, 1062 }));
            questsCanBeRun.Add(new Quest_1069(8, 17, QuestRace.Ferre, new uint[] { 1068 }));
            questsCanBeRun.Add(new Quest_1445(8, 17, QuestRace.Ferre, new uint[] { 1069 }));
            questsCanBeRun.Add(new Quest_3447(8, 17, QuestRace.Ferre, new uint[] { 3446 }));
            questsCanBeRun.Add(new Quest_1076(8, 17, QuestRace.Ferre, new uint[] { 3446 }));
            questsCanBeRun.Add(new Quest_1171(8, 17, QuestRace.Ferre, new uint[] { 3446 }));
            questsCanBeRun.Add(new Quest_3448(8, 17, QuestRace.Ferre, new uint[] { 3447 }));
            questsCanBeRun.Add(new Quest_3449(8, 17, QuestRace.Ferre, new uint[] { 3448 }));
            questsCanBeRun.Add(new Quest_1071(8, 17, QuestRace.Ferre, new uint[] { 1171 }));
            questsCanBeRun.Add(new Quest_1070(8, 17, QuestRace.Ferre, new uint[] { 3446 }));
            questsCanBeRun.Add(new Quest_1172(8, 17, QuestRace.Ferre, new uint[] { 1076 }));
            questsCanBeRun.Add(new Quest_1075(8, 17, QuestRace.Ferre, new uint[] { 1172 }));
            questsCanBeRun.Add(new Quest_2423(8, 17, QuestRace.Ferre, new uint[] { 3449 }));
            questsCanBeRun.Add(new Quest_2424(8, 17, QuestRace.Ferre, new uint[] { 2423 }));
            questsCanBeRun.Add(new Quest_1078(8, 17, QuestRace.Ferre, new uint[] { 2423 }));
            questsCanBeRun.Add(new Quest_1081(8, 17, QuestRace.Ferre, new uint[] { 1078 }));
            questsCanBeRun.Add(new Quest_1080(8, 17, QuestRace.Ferre, new uint[] { 1081 }));
            questsCanBeRun.Add(new Quest_1063(8, 17, QuestRace.Ferre, new uint[] { 1080 }));
            questsCanBeRun.Add(new Quest_1083(8, 17, QuestRace.Ferre, new uint[] { 1063 }));
            questsCanBeRun.Add(new Quest_1085(8, 17, QuestRace.Ferre, new uint[] { 1083 }));
            questsCanBeRun.Add(new Quest_1086(8, 17, QuestRace.Ferre, new uint[] { 1083 }));
            questsCanBeRun.Add(new Quest_1077(8, 17, QuestRace.Ferre, new uint[] { 1085 }));
            questsCanBeRun.Add(new Quest_1174(8, 17, QuestRace.Ferre, new uint[] { 1077 }));
            questsCanBeRun.Add(new Quest_6216(8, 17, QuestRace.Ferre, new uint[] { 1174 }));
            questsCanBeRun.Add(new Quest_6214(8, 17, QuestRace.Ferre, new uint[] { 1174 }));
            questsCanBeRun.Add(new Quest_1090(8, 17, QuestRace.Ferre, new uint[] { 1174 }));
            questsCanBeRun.Add(new Quest_1092(8, 17, QuestRace.Ferre, new uint[] { 1090 }));
            questsCanBeRun.Add(new Quest_1102(8, 17, QuestRace.Ferre, new uint[] { 1092 }));
            questsCanBeRun.Add(new Quest_1088(8, 17, QuestRace.Ferre, new uint[] { 1102 }));
            questsCanBeRun.Add(new Quest_1093(8, 17, QuestRace.Ferre, new uint[] { 1088 }));
            questsCanBeRun.Add(new Quest_1094(8, 17, QuestRace.Ferre, new uint[] { 1093 }));
            questsCanBeRun.Add(new Quest_2425(8, 17, QuestRace.Ferre, new uint[] { 2424 }));
            questsCanBeRun.Add(new Quest_3451(8, 17, QuestRace.Ferre, new uint[] { 2425 }));
            questsCanBeRun.Add(new Quest_3452(8, 17, QuestRace.Ferre, new uint[] { 3451 }));
            questsCanBeRun.Add(new Quest_1073(8, 17, QuestRace.Ferre, new uint[] { 1094 }));
            questsCanBeRun.Add(new Quest_1104(8, 17, QuestRace.Ferre, new uint[] { 1094 }));
            questsCanBeRun.Add(new Quest_1096(8, 17, QuestRace.Ferre, new uint[] { 1104, 1073 }));
            questsCanBeRun.Add(new Quest_1105(8, 17, QuestRace.Ferre, new uint[] { 1104, 1073 }));
            questsCanBeRun.Add(new Quest_1106(8, 17, QuestRace.Ferre, new uint[] { 1105 }));
            questsCanBeRun.Add(new Quest_1175(8, 17, QuestRace.Ferre, new uint[] { 1106 }));
            questsCanBeRun.Add(new Quest_1108(8, 17, QuestRace.Ferre, new uint[] { 1175, 1096 }));
            questsCanBeRun.Add(new Quest_1099(8, 17, QuestRace.Ferre, new uint[] { 1175, 1096 }));
            questsCanBeRun.Add(new Quest_1098(8, 17, QuestRace.Ferre, new uint[] { 1175, 1096 }, new uint[] { 1110 }));     //daily
            questsCanBeRun.Add(new Quest_1100(8, 17, QuestRace.Ferre, new uint[] { 1108 }));
            questsCanBeRun.Add(new Quest_1109(8, 17, QuestRace.Ferre, new uint[] { 1099, 1100 }));
            questsCanBeRun.Add(new Quest_1107(8, 17, QuestRace.Ferre, new uint[] { 1109 }));
            questsCanBeRun.Add(new Quest_1110(8, 17, QuestRace.Ferre, new uint[] { 1107 }));
            questsCanBeRun.Add(new Quest_1095(8, 17, QuestRace.Ferre, new uint[] { 1107 }));
            questsCanBeRun.Add(new Quest_1111(8, 17, QuestRace.Ferre, new uint[] { 1095, 1110 }));
            #endregion
            #region Mahadevi
            questsCanBeRun.Add(new Quest_2128(12, 22, QuestRace.Ferre, new uint[] { 1095, 1110 }));
            questsCanBeRun.Add(new Quest_2124(12, 22, QuestRace.Ferre, new uint[] { 1095, 1110 }));
            questsCanBeRun.Add(new Quest_2125(12, 22, QuestRace.Ferre, new uint[] { 2124, 2128 }));
            questsCanBeRun.Add(new Quest_857(12, 22, QuestRace.Ferre, new uint[] { 2124, 2128 }));
            questsCanBeRun.Add(new Quest_861(12, 22, QuestRace.Ferre, new uint[] { 857, 1111, 2125, 3452 }));
            questsCanBeRun.Add(new Quest_908(12, 22, QuestRace.Ferre, new uint[] { 861 }));
            questsCanBeRun.Add(new Quest_858(12, 22, QuestRace.Ferre, new uint[] { 908 }));
            questsCanBeRun.Add(new Quest_1500(12, 22, QuestRace.Ferre, new uint[] { 858 }));
            questsCanBeRun.Add(new Quest_3453(12, 22, QuestRace.Ferre, new uint[] { 1500 }));
            questsCanBeRun.Add(new Quest_3454(12, 22, QuestRace.Ferre, new uint[] { 3453 }));
            questsCanBeRun.Add(new Quest_3455(12, 22, QuestRace.Ferre, new uint[] { 3454 }));
            questsCanBeRun.Add(new Quest_2129(12, 22, QuestRace.Ferre, new uint[] { 3454 }));
            questsCanBeRun.Add(new Quest_859(12, 22, QuestRace.Ferre, new uint[] { 3454 }));
            questsCanBeRun.Add(new Quest_893(12, 22, QuestRace.Ferre, new uint[] { 3454 }));
            questsCanBeRun.Add(new Quest_888(12, 22, QuestRace.Ferre, new uint[] { 859 }));
            questsCanBeRun.Add(new Quest_3307(12, 22, QuestRace.Ferre, new uint[] { 859 }));
            questsCanBeRun.Add(new Quest_3306(12, 22, QuestRace.Ferre, new uint[] { 3307 }));
            questsCanBeRun.Add(new Quest_3305(12, 22, QuestRace.Ferre, new uint[] { 3306 }));
            questsCanBeRun.Add(new Quest_3308(12, 22, QuestRace.Ferre, new uint[] { 3305 }));
            questsCanBeRun.Add(new Quest_3456(12, 22, QuestRace.Ferre, new uint[] { 888, 3455, 2129 }));
            questsCanBeRun.Add(new Quest_2896(12, 22, QuestRace.Ferre, new uint[] { 888, 3455, 2129 }));
            questsCanBeRun.Add(new Quest_3491(12, 22, QuestRace.Ferre, new uint[] { 3456 }));
            questsCanBeRun.Add(new Quest_3457(12, 22, QuestRace.Ferre, new uint[] { 3491 }));
            questsCanBeRun.Add(new Quest_3459(12, 22, QuestRace.Ferre, new uint[] { 3457 }));
            questsCanBeRun.Add(new Quest_3460(12, 22, QuestRace.Ferre, new uint[] { 3459 }));
            questsCanBeRun.Add(new Quest_3461(12, 22, QuestRace.Ferre, new uint[] { 3460 }));
            questsCanBeRun.Add(new Quest_3462(12, 22, QuestRace.Ferre, new uint[] { 3461 }));
            questsCanBeRun.Add(new Quest_2897(12, 22, QuestRace.Ferre, new uint[] { 2896 }));
            questsCanBeRun.Add(new Quest_2898(12, 22, QuestRace.Ferre, new uint[] { 2897 }));
            questsCanBeRun.Add(new Quest_885(12, 22, QuestRace.Ferre, new uint[] { 2898 }));
            questsCanBeRun.Add(new Quest_3463(12, 25, QuestRace.Ferre, new uint[] { 3462 }));
            questsCanBeRun.Add(new Quest_1694(12, 22, QuestRace.Ferre, new uint[] { 3462 }));
            questsCanBeRun.Add(new Quest_2133(12, 22, QuestRace.Ferre, new uint[] { 3462 }, new uint[] { 1502 }));   //daily
            questsCanBeRun.Add(new Quest_3598(12, 22, QuestRace.Ferre, new uint[] { 3462 }));
            questsCanBeRun.Add(new Quest_2134(12, 22, QuestRace.Ferre, new uint[] { 3598 }));
            questsCanBeRun.Add(new Quest_2135(12, 22, QuestRace.Ferre, new uint[] { 2134, 885, 1694 }));
            questsCanBeRun.Add(new Quest_2136(12, 22, QuestRace.Ferre, new uint[] { 2135 }));
            questsCanBeRun.Add(new Quest_3604(12, 22, QuestRace.Ferre, new uint[] { 2136 }));
            questsCanBeRun.Add(new Quest_1502(12, 22, QuestRace.Ferre, new uint[] { 2136 }));
            questsCanBeRun.Add(new Quest_1503(12, 22, QuestRace.Ferre, new uint[] { 1502 }));
            questsCanBeRun.Add(new Quest_886(12, 22, QuestRace.Ferre, new uint[] { 3604 }));
            questsCanBeRun.Add(new Quest_1686(12, 22, QuestRace.Ferre, new uint[] { 886 }));
            questsCanBeRun.Add(new Quest_4036(12, 22, QuestRace.Ferre, new uint[] { 1503 }));
            questsCanBeRun.Add(new Quest_3310(12, 22, QuestRace.Ferre, new uint[] { 4036 }));
            questsCanBeRun.Add(new Quest_3309(12, 22, QuestRace.Ferre, new uint[] { 4036 }));
            questsCanBeRun.Add(new Quest_4035(12, 22, QuestRace.Ferre, new uint[] { 4036 }));
            questsCanBeRun.Add(new Quest_1504(12, 22, QuestRace.Ferre, new uint[] { 1686 }));
            questsCanBeRun.Add(new Quest_2902(12, 22, QuestRace.Ferre, new uint[] { 1686 }, new uint[] { 1505 }));    //daily
            questsCanBeRun.Add(new Quest_1687(12, 22, QuestRace.Ferre, new uint[] { 1504 }));
            questsCanBeRun.Add(new Quest_2901(12, 22, QuestRace.Ferre, new uint[] { 1504 }));
            questsCanBeRun.Add(new Quest_1505(12, 22, QuestRace.Ferre, new uint[] { 1687 }));
            questsCanBeRun.Add(new Quest_1507(12, 22, QuestRace.Ferre, new uint[] { 1505 }));
            questsCanBeRun.Add(new Quest_876(12, 22, QuestRace.Ferre, new uint[] { 1507 }));
            questsCanBeRun.Add(new Quest_870(12, 22, QuestRace.Ferre, new uint[] { 876 }));
            questsCanBeRun.Add(new Quest_871(12, 22, QuestRace.Ferre, new uint[] { 870 }));
            questsCanBeRun.Add(new Quest_873(12, 22, QuestRace.Ferre, new uint[] { 871 }));
            questsCanBeRun.Add(new Quest_879(12, 22, QuestRace.Ferre, new uint[] { 871 }));
            questsCanBeRun.Add(new Quest_872(12, 22, QuestRace.Ferre, new uint[] { 873, 879 }));
            questsCanBeRun.Add(new Quest_880(12, 22, QuestRace.Ferre, new uint[] { 873, 879 }));
            questsCanBeRun.Add(new Quest_2904(12, 22, QuestRace.Ferre, new uint[] { 873, 879 }, new uint[] { 2138 }));   //daily
            questsCanBeRun.Add(new Quest_2903(12, 22, QuestRace.Ferre, new uint[] { 873, 879 }));
            questsCanBeRun.Add(new Quest_917(12, 22, QuestRace.Ferre, new uint[] { 872 }));
            questsCanBeRun.Add(new Quest_2138(12, 22, QuestRace.Ferre, new uint[] { 917 }));
            questsCanBeRun.Add(new Quest_875(12, 22, QuestRace.Ferre, new uint[] { 2138 }));
            questsCanBeRun.Add(new Quest_874(12, 22, QuestRace.Ferre, new uint[] { 2138 }));
            questsCanBeRun.Add(new Quest_3606(12, 22, QuestRace.Ferre, new uint[] { 874, 875 }));   
            questsCanBeRun.Add(new Quest_863(12, 22, QuestRace.Ferre, new uint[] { 3606 }));
            questsCanBeRun.Add(new Quest_1508(12, 22, QuestRace.Ferre, new uint[] { 863 }));
            questsCanBeRun.Add(new Quest_1509(12, 22, QuestRace.Ferre, new uint[] { 1508 }));
            questsCanBeRun.Add(new Quest_1510(12, 22, QuestRace.Ferre, new uint[] { 1509 }));
            questsCanBeRun.Add(new Quest_1514(12, 22, QuestRace.Ferre, new uint[] { 1509 }));
            questsCanBeRun.Add(new Quest_899(12, 22, QuestRace.Ferre, new uint[] { 1509 }));
            questsCanBeRun.Add(new Quest_1512(12, 22, QuestRace.Ferre, new uint[] { 1509 }));
            questsCanBeRun.Add(new Quest_1511(12, 22, QuestRace.Ferre, new uint[] { 1509 }));
            questsCanBeRun.Add(new Quest_1691(12, 22, QuestRace.Ferre, new uint[] { 1511 }));
            questsCanBeRun.Add(new Quest_925(12, 22, QuestRace.Ferre, new uint[] { 1510, 1512, 1514, 899 }));
            questsCanBeRun.Add(new Quest_2139(12, 22, QuestRace.Ferre, new uint[] { 925 }));
            questsCanBeRun.Add(new Quest_2906(12, 22, QuestRace.Ferre, new uint[] { 2139 }));
            questsCanBeRun.Add(new Quest_900(12, 22, QuestRace.Ferre, new uint[] { 2139 }));
            questsCanBeRun.Add(new Quest_877(12, 22, QuestRace.Ferre, new uint[] { 2139 }, new uint[] { 3312 }));        //daily
            questsCanBeRun.Add(new Quest_1517(12, 22, QuestRace.Ferre, new uint[] { 2906, 900 }));
            questsCanBeRun.Add(new Quest_3609(12, 22, QuestRace.Ferre, new uint[] { 2906, 900 }));
            questsCanBeRun.Add(new Quest_4311(12, 22, QuestRace.Ferre, new uint[] { 1517, 3609 }));
            questsCanBeRun.Add(new Quest_878(12, 22, QuestRace.Ferre, new uint[] { 1517, 3609 }));
            questsCanBeRun.Add(new Quest_3312(12, 22, QuestRace.Ferre, new uint[] { 4311 }));
            questsCanBeRun.Add(new Quest_3313(12, 22, QuestRace.Ferre, new uint[] { 4311 }));
            #endregion
            #region Solis Headlands
            questsCanBeRun.Add(new Quest_1668(17, 27, QuestRace.Ferre, new uint[] { 878 }));
            questsCanBeRun.Add(new Quest_1667(17, 27, QuestRace.Ferre, new uint[] { 1668 }));
            questsCanBeRun.Add(new Quest_1731(17, 27, QuestRace.Ferre, new uint[] { 1667 }));
            questsCanBeRun.Add(new Quest_951(17, 27, QuestRace.Ferre, new uint[] { 1731 }, new uint[] { 949 }));    //daily
            questsCanBeRun.Add(new Quest_942(17, 27, QuestRace.Ferre, new uint[] { 1731 }));
            questsCanBeRun.Add(new Quest_943(17, 27, QuestRace.Ferre, new uint[] { 1731 }));
            questsCanBeRun.Add(new Quest_3645(17, 27, QuestRace.Ferre, new uint[] { 1731 }));
            questsCanBeRun.Add(new Quest_3646(17, 27, QuestRace.Ferre, new uint[] { 3645 }));
            questsCanBeRun.Add(new Quest_949(17, 27, QuestRace.Ferre, new uint[] { 942, 943 }));
            questsCanBeRun.Add(new Quest_950(17, 27, QuestRace.Ferre, new uint[] { 949 }));
            questsCanBeRun.Add(new Quest_748(17, 27, QuestRace.Ferre, new uint[] { 950 }));
            questsCanBeRun.Add(new Quest_3464(17, 27, QuestRace.Ferre, new uint[] { 3463 }));
            questsCanBeRun.Add(new Quest_3466(17, 27, QuestRace.Ferre, new uint[] { 3464 }));
            questsCanBeRun.Add(new Quest_3450(17, 27, QuestRace.Ferre, new uint[] { 3466 }));
            questsCanBeRun.Add(new Quest_3467(17, 27, QuestRace.Ferre, new uint[] { 3450 }));
            questsCanBeRun.Add(new Quest_3649(17, 27, QuestRace.Ferre, new uint[] { 3450 }));
            questsCanBeRun.Add(new Quest_3651(17, 27, QuestRace.Ferre, new uint[] { 3649 }));
            questsCanBeRun.Add(new Quest_3652(17, 27, QuestRace.Ferre, new uint[] { 3651 }));
            questsCanBeRun.Add(new Quest_752(17, 27, QuestRace.Ferre, new uint[] { 3652 }));
            questsCanBeRun.Add(new Quest_764(17, 27, QuestRace.Ferre, new uint[] { 752 }, new uint[] { 3653 }));     //daily
            questsCanBeRun.Add(new Quest_765(17, 27, QuestRace.Ferre, new uint[] { 752 }));
            questsCanBeRun.Add(new Quest_766(17, 27, QuestRace.Ferre, new uint[] { 752 }));
            questsCanBeRun.Add(new Quest_750(17, 27, QuestRace.Ferre, new uint[] { 752 }));
            questsCanBeRun.Add(new Quest_4443(17, 27, QuestRace.Ferre, new uint[] { 752 }));
            questsCanBeRun.Add(new Quest_3707(17, 27, QuestRace.Ferre, new uint[] { 4443 }));
            questsCanBeRun.Add(new Quest_3653(17, 27, QuestRace.Ferre, new uint[] { 750, 765, 766 }));
            questsCanBeRun.Add(new Quest_756(17, 27, QuestRace.Ferre, new uint[] { 3653 }));
            questsCanBeRun.Add(new Quest_1675(17, 27, QuestRace.Ferre, new uint[] { 756 }));
            questsCanBeRun.Add(new Quest_753(17, 27, QuestRace.Ferre, new uint[] { 756 }));
            questsCanBeRun.Add(new Quest_754(17, 27, QuestRace.Ferre, new uint[] { 756 }));
            questsCanBeRun.Add(new Quest_3658(17, 27, QuestRace.Ferre, new uint[] { 756 }));
            questsCanBeRun.Add(new Quest_755(17, 27, QuestRace.Ferre, new uint[] { 756 }));
            questsCanBeRun.Add(new Quest_1677(17, 27, QuestRace.Ferre, new uint[] { 1675 }));
            questsCanBeRun.Add(new Quest_1678(17, 27, QuestRace.Ferre, new uint[] { 1677 }));
            questsCanBeRun.Add(new Quest_1679(17, 27, QuestRace.Ferre, new uint[] { 1678 }));
            questsCanBeRun.Add(new Quest_1676(17, 27, QuestRace.Ferre, new uint[] { 1679 }));
            questsCanBeRun.Add(new Quest_3657(17, 27, QuestRace.Ferre, new uint[] { 753, 754, 755, 3658 }));
            questsCanBeRun.Add(new Quest_1732(17, 27, QuestRace.Ferre, new uint[] { 3657 }));
            questsCanBeRun.Add(new Quest_3660(17, 27, QuestRace.Ferre, new uint[] { 1732 }));
            questsCanBeRun.Add(new Quest_3661(17, 27, QuestRace.Ferre, new uint[] { 3660 }));
            questsCanBeRun.Add(new Quest_3663(17, 27, QuestRace.Ferre, new uint[] { 3660 }));
            questsCanBeRun.Add(new Quest_3664(17, 27, QuestRace.Ferre, new uint[] { 3661, 3663 }));
            questsCanBeRun.Add(new Quest_3666(17, 27, QuestRace.Ferre, new uint[] { 3664 }));
            questsCanBeRun.Add(new Quest_3668(17, 27, QuestRace.Ferre, new uint[] { 3666 }));
            questsCanBeRun.Add(new Quest_3667(17, 27, QuestRace.Ferre, new uint[] { 3668 }));
            questsCanBeRun.Add(new Quest_3669(17, 27, QuestRace.Ferre, new uint[] { 3667 }));
            questsCanBeRun.Add(new Quest_3468(17, 27, QuestRace.Ferre, new uint[] { 3467 }));
            questsCanBeRun.Add(new Quest_3469(17, 27, QuestRace.Ferre, new uint[] { 3468 }));
            questsCanBeRun.Add(new Quest_3470(17, 27, QuestRace.Ferre, new uint[] { 3469 }));
            questsCanBeRun.Add(new Quest_3471(17, 27, QuestRace.Ferre, new uint[] { 3470 }));
            questsCanBeRun.Add(new Quest_3472(17, 27, QuestRace.Ferre, new uint[] { 3471 }));
            questsCanBeRun.Add(new Quest_3670(17, 27, QuestRace.Ferre, new uint[] { 3669 }));
            questsCanBeRun.Add(new Quest_3672(17, 27, QuestRace.Ferre, new uint[] { 3669 }));
            questsCanBeRun.Add(new Quest_3674(17, 27, QuestRace.Ferre, new uint[] { 3672 }));
            questsCanBeRun.Add(new Quest_3677(17, 27, QuestRace.Ferre, new uint[] { 3674, 3670 }, new uint[] { 773 }));     //daily
            questsCanBeRun.Add(new Quest_3678(17, 27, QuestRace.Ferre, new uint[] { 3674, 3670 }));
            questsCanBeRun.Add(new Quest_784(17, 27, QuestRace.Ferre, new uint[] { 3674, 3670 }));
            questsCanBeRun.Add(new Quest_1709(17, 27, QuestRace.Ferre, new uint[] { 3674, 3670 }));
            questsCanBeRun.Add(new Quest_947(17, 27, QuestRace.Ferre, new uint[] { 3674, 3670 }));
            questsCanBeRun.Add(new Quest_3675(17, 27, QuestRace.Ferre, new uint[] { 3678, 784, 1709, 947 }));
            questsCanBeRun.Add(new Quest_773(17, 27, QuestRace.Ferre, new uint[] { 3675 }));
            questsCanBeRun.Add(new Quest_783(17, 27, QuestRace.Ferre, new uint[] { 773 }));
            questsCanBeRun.Add(new Quest_3680(17, 27, QuestRace.Ferre, new uint[] { 773 }));
            questsCanBeRun.Add(new Quest_782(17, 27, QuestRace.Ferre, new uint[] { 3680, 783 }));
            questsCanBeRun.Add(new Quest_3679(17, 27, QuestRace.Ferre, new uint[] { 782 }));
            questsCanBeRun.Add(new Quest_774(17, 27, QuestRace.Ferre, new uint[] { 3679 }));
            questsCanBeRun.Add(new Quest_775(17, 27, QuestRace.Ferre, new uint[] { 774 }));
            questsCanBeRun.Add(new Quest_3683(17, 27, QuestRace.Ferre, new uint[] { 775 }));
            questsCanBeRun.Add(new Quest_3686(17, 27, QuestRace.Ferre, new uint[] { 3683 }));
            questsCanBeRun.Add(new Quest_3689(17, 27, QuestRace.Ferre, new uint[] { 3686 }));
            questsCanBeRun.Add(new Quest_3690(17, 27, QuestRace.Ferre, new uint[] { 3689 }));
            questsCanBeRun.Add(new Quest_3701(17, 27, QuestRace.Ferre, new uint[] { 3690 }));
            questsCanBeRun.Add(new Quest_3704(17, 27, QuestRace.Ferre, new uint[] { 3701 }));
            questsCanBeRun.Add(new Quest_3691(17, 27, QuestRace.Ferre, new uint[] { 3704 }));
            questsCanBeRun.Add(new Quest_3696(17, 27, QuestRace.Ferre, new uint[] { 3691 }));
            questsCanBeRun.Add(new Quest_3692(17, 27, QuestRace.Ferre, new uint[] { 3696 }));
            questsCanBeRun.Add(new Quest_3693(17, 27, QuestRace.Ferre, new uint[] { 3696 }, new uint[] { 1688 }));       //daily
            questsCanBeRun.Add(new Quest_777(17, 27, QuestRace.Ferre, new uint[] { 3696 }));
            questsCanBeRun.Add(new Quest_776(17, 27, QuestRace.Ferre, new uint[] { 3696 }));
            questsCanBeRun.Add(new Quest_792(17, 27, QuestRace.Ferre, new uint[] { 3696 }));
            questsCanBeRun.Add(new Quest_1688(17, 27, QuestRace.Ferre, new uint[] { 792, 3692, 3693, 777, 776 }));
            questsCanBeRun.Add(new Quest_785(17, 27, QuestRace.Ferre, new uint[] { 1688 }));
            questsCanBeRun.Add(new Quest_788(17, 27, QuestRace.Ferre, new uint[] { 785 }));
            questsCanBeRun.Add(new Quest_3699(17, 27, QuestRace.Ferre, new uint[] { 785 }));
            questsCanBeRun.Add(new Quest_793(17, 27, QuestRace.Ferre, new uint[] { 785 }));
            questsCanBeRun.Add(new Quest_1682(17, 27, QuestRace.Ferre, new uint[] { 785 }));
            questsCanBeRun.Add(new Quest_3700(17, 27, QuestRace.Ferre, new uint[] { 1682, 793, 3699, 788 }));
            questsCanBeRun.Add(new Quest_795(17, 27, QuestRace.Ferre, new uint[] { 3700 }));
            #endregion

            #region Singing Land
            questsCanBeRun.Add(new Quest_1857(20, 30, QuestRace.Ferre, new uint[] { 795 }));
            questsCanBeRun.Add(new Quest_1858(20, 30, QuestRace.Ferre, new uint[] { 795 }));
            questsCanBeRun.Add(new Quest_1859(20, 30, QuestRace.Ferre, new uint[] { 1857, 1858 }));
            questsCanBeRun.Add(new Quest_855(20, 30, QuestRace.Ferre, new uint[] { 1859 }));
            questsCanBeRun.Add(new Quest_1861(20, 30, QuestRace.Ferre, new uint[] { 855 }));
            questsCanBeRun.Add(new Quest_1863(20, 30, QuestRace.Ferre, new uint[] { 1861 }));
            questsCanBeRun.Add(new Quest_1860(20, 30, QuestRace.Ferre, new uint[] { 1863 }));
            questsCanBeRun.Add(new Quest_1864(20, 30, QuestRace.Ferre, new uint[] { 1860 }));
            questsCanBeRun.Add(new Quest_799(20, 30, QuestRace.Ferre, new uint[] { 1864 }));
            questsCanBeRun.Add(new Quest_800(20, 30, QuestRace.Ferre, new uint[] { 799 }));
            questsCanBeRun.Add(new Quest_798(20, 30, QuestRace.Ferre, new uint[] { 800 }));
            questsCanBeRun.Add(new Quest_797(20, 30, QuestRace.Ferre, new uint[] { 800 }));
            questsCanBeRun.Add(new Quest_802(20, 30, QuestRace.Ferre, new uint[] { 798, 797 }));
            questsCanBeRun.Add(new Quest_796(20, 30, QuestRace.Ferre, new uint[] { 802 }));
            questsCanBeRun.Add(new Quest_813(20, 30, QuestRace.Ferre, new uint[] { 796 }));
            questsCanBeRun.Add(new Quest_801(20, 30, QuestRace.Ferre, new uint[] { 796 }));
            questsCanBeRun.Add(new Quest_810(20, 30, QuestRace.Ferre, new uint[] { 796 }));
            questsCanBeRun.Add(new Quest_809(20, 30, QuestRace.Ferre, new uint[] { 796 }));
            //814  - бот не умеет стрелять из чужого слейва
            questsCanBeRun.Add(new Quest_2045(20, 30, QuestRace.Ferre, new uint[] { 809, 810, 801, 813 }));
            questsCanBeRun.Add(new Quest_3473(20, 30, QuestRace.Ferre, new uint[] { 2045, 3472 }));
            questsCanBeRun.Add(new Quest_806(20, 30, QuestRace.Ferre, new uint[] { 2045, 3472 }));
            questsCanBeRun.Add(new Quest_3474(20, 30, QuestRace.Ferre, new uint[] { 3473 }));
            questsCanBeRun.Add(new Quest_3475(20, 30, QuestRace.Ferre, new uint[] { 3474 }));
            questsCanBeRun.Add(new Quest_3476(20, 30, QuestRace.Ferre, new uint[] { 3475 }));
            questsCanBeRun.Add(new Quest_3478(20, 30, QuestRace.Ferre, new uint[] { 3476 }));
            questsCanBeRun.Add(new Quest_3479(20, 30, QuestRace.Ferre, new uint[] { 3478 }));
            questsCanBeRun.Add(new Quest_807(20, 30, QuestRace.Ferre, new uint[] { 806 }));
            questsCanBeRun.Add(new Quest_849(20, 30, QuestRace.Ferre, new uint[] { 806 }));
            questsCanBeRun.Add(new Quest_811(20, 30, QuestRace.Ferre, new uint[] { 806 }));
            questsCanBeRun.Add(new Quest_1852(20, 30, QuestRace.Ferre, new uint[] { 806 }));
            questsCanBeRun.Add(new Quest_812(20, 30, QuestRace.Ferre, new uint[] { 806 }));
            questsCanBeRun.Add(new Quest_819(20, 30, QuestRace.Ferre, new uint[] { 807 }));
            questsCanBeRun.Add(new Quest_820(20, 30, QuestRace.Ferre, new uint[] { 807 }));
            //questsCanBeRun.Add(new Quest_1227(20, 30, QuestRace.Ferre, new uint[] { 807 }, new uint[] { 824 }));        //daily можно сделать только днем адекватно.
            questsCanBeRun.Add(new Quest_815(20, 30, QuestRace.Ferre, new uint[] { 807 }));
            questsCanBeRun.Add(new Quest_2057(20, 30, QuestRace.Ferre, new uint[] { 815 }));
            questsCanBeRun.Add(new Quest_816(20, 30, QuestRace.Ferre, new uint[] { 2057 }));
            questsCanBeRun.Add(new Quest_1876(20, 30, QuestRace.Ferre, new uint[] { 816 }));
            questsCanBeRun.Add(new Quest_824(20, 30, QuestRace.Ferre, new uint[] { 1876, 820, 819 }));
            questsCanBeRun.Add(new Quest_825(20, 30, QuestRace.Ferre, new uint[] { 824 }));
            questsCanBeRun.Add(new Quest_818(20, 30, QuestRace.Ferre, new uint[] { 825 }));
            questsCanBeRun.Add(new Quest_822(20, 30, QuestRace.Ferre, new uint[] { 818 }));
            questsCanBeRun.Add(new Quest_823(20, 30, QuestRace.Ferre, new uint[] { 822 }));
            questsCanBeRun.Add(new Quest_821(20, 30, QuestRace.Ferre, new uint[] { 823 }));
            questsCanBeRun.Add(new Quest_826(20, 30, QuestRace.Ferre, new uint[] { 821 }));
            questsCanBeRun.Add(new Quest_836(20, 30, QuestRace.Ferre, new uint[] { 826 }));
            questsCanBeRun.Add(new Quest_817(20, 30, QuestRace.Ferre, new uint[] { 826 }));
            questsCanBeRun.Add(new Quest_833(20, 30, QuestRace.Ferre, new uint[] { 836 }));
            questsCanBeRun.Add(new Quest_830(20, 30, QuestRace.Ferre, new uint[] { 836 }));
            questsCanBeRun.Add(new Quest_835(20, 30, QuestRace.Ferre, new uint[] { 833 }));
            questsCanBeRun.Add(new Quest_831(20, 30, QuestRace.Ferre, new uint[] { 835 }));
            questsCanBeRun.Add(new Quest_832(20, 30, QuestRace.Ferre, new uint[] { 831, 830 }));
            questsCanBeRun.Add(new Quest_837(20, 30, QuestRace.Ferre, new uint[] { 832 }));
            questsCanBeRun.Add(new Quest_834(20, 30, QuestRace.Ferre, new uint[] { 832 }));
            questsCanBeRun.Add(new Quest_838(20, 30, QuestRace.Ferre, new uint[] { 832 }));
            questsCanBeRun.Add(new Quest_1856(20, 30, QuestRace.Ferre, new uint[] { 834 }));
            questsCanBeRun.Add(new Quest_829(20, 30, QuestRace.Ferre, new uint[] { 1856 }));
            questsCanBeRun.Add(new Quest_1854(20, 30, QuestRace.Ferre, new uint[] { 829, 837, 838 }));
            questsCanBeRun.Add(new Quest_841(20, 30, QuestRace.Ferre, new uint[] { 829, 837, 838 }));
            questsCanBeRun.Add(new Quest_843(20, 30, QuestRace.Ferre, new uint[] { 841, 1854 }));
            questsCanBeRun.Add(new Quest_839(20, 30, QuestRace.Ferre, new uint[] { 841, 1854 }));
            questsCanBeRun.Add(new Quest_1851(20, 30, QuestRace.Ferre, new uint[] { 843, 839 }));
            questsCanBeRun.Add(new Quest_844(20, 30, QuestRace.Ferre, new uint[] { 843, 839 }));
            questsCanBeRun.Add(new Quest_842(20, 30, QuestRace.Ferre, new uint[] { 843, 839 }));
            questsCanBeRun.Add(new Quest_840(20, 30, QuestRace.Ferre, new uint[] { 1851, 844, 842 }));
            questsCanBeRun.Add(new Quest_1464(20, 30, QuestRace.Ferre, new uint[] { 1851, 844, 842 }));
            questsCanBeRun.Add(new Quest_1463(20, 30, QuestRace.Ferre, new uint[] { 840 }));
            questsCanBeRun.Add(new Quest_906(20, 30, QuestRace.Ferre, new uint[] { 840 }));
            questsCanBeRun.Add(new Quest_856(20, 30, QuestRace.Ferre, new uint[] { 840 }));
            questsCanBeRun.Add(new Quest_963(20, 30, QuestRace.Ferre, new uint[] { 906 }));
            questsCanBeRun.Add(new Quest_1415(20, 30, QuestRace.Ferre, new uint[] { 906 }));
            questsCanBeRun.Add(new Quest_1435(20, 30, QuestRace.Ferre, new uint[] { 856 }));
            questsCanBeRun.Add(new Quest_846(20, 30, QuestRace.Ferre, new uint[] { 1435 }));
            questsCanBeRun.Add(new Quest_848(20, 30, QuestRace.Ferre, new uint[] { 846 }));
            questsCanBeRun.Add(new Quest_845(20, 30, QuestRace.Ferre, new uint[] { 848 }));
            questsCanBeRun.Add(new Quest_851(20, 30, QuestRace.Ferre, new uint[] { 845 }));
            questsCanBeRun.Add(new Quest_852(20, 30, QuestRace.Ferre, new uint[] { 845 }));
            questsCanBeRun.Add(new Quest_853(20, 30, QuestRace.Ferre, new uint[] { 845 }));
            questsCanBeRun.Add(new Quest_854(20, 30, QuestRace.Ferre, new uint[] { 852 }));
            questsCanBeRun.Add(new Quest_847(20, 30, QuestRace.Ferre, new uint[] { 854 }));
            questsCanBeRun.Add(new Quest_1865(20, 30, QuestRace.Ferre, new uint[] { 853 }));
            #endregion
            #region Old Forest
            questsCanBeRun.Add(new Quest_1303(23, 30, QuestRace.Ferre, new uint[] { 1865 }));
            questsCanBeRun.Add(new Quest_1305(23, 30, QuestRace.Ferre, new uint[] { 1865 }));
            questsCanBeRun.Add(new Quest_1304(23, 30, QuestRace.Ferre, new uint[] { 1303, 1305 }));
            questsCanBeRun.Add(new Quest_3905(23, 30, QuestRace.Ferre, new uint[] { 1303, 1305 }));
            questsCanBeRun.Add(new Quest_1311(23, 30, QuestRace.Ferre, new uint[] { 1304 }));
            questsCanBeRun.Add(new Quest_1312(23, 30, QuestRace.Ferre, new uint[] { 1311 }));
            questsCanBeRun.Add(new Quest_1313(23, 30, QuestRace.Ferre, new uint[] { 1312 }));
            questsCanBeRun.Add(new Quest_1310(23, 30, QuestRace.Ferre, new uint[] { 1313 }));
            questsCanBeRun.Add(new Quest_1306(23, 30, QuestRace.Ferre, new uint[] { 1313 }));
            questsCanBeRun.Add(new Quest_1307(23, 30, QuestRace.Ferre, new uint[] { 1313 }));
            questsCanBeRun.Add(new Quest_2060(23, 30, QuestRace.Ferre, new uint[] { 1313 }));
            questsCanBeRun.Add(new Quest_1308(23, 30, QuestRace.Ferre, new uint[] { 1310, 1306, 1307 }));
            questsCanBeRun.Add(new Quest_3480(23, 30, QuestRace.Ferre, new uint[] { 1310, 1306, 1307 }));
            questsCanBeRun.Add(new Quest_1320(23, 30, QuestRace.Ferre, new uint[] { 1308 }));
            questsCanBeRun.Add(new Quest_1834(23, 30, QuestRace.Ferre, new uint[] { 1320 }));
            questsCanBeRun.Add(new Quest_1316(23, 30, QuestRace.Ferre, new uint[] { 1834 }));
            questsCanBeRun.Add(new Quest_1314(23, 30, QuestRace.Ferre, new uint[] { 1834 }));
            questsCanBeRun.Add(new Quest_2559(23, 30, QuestRace.Ferre, new uint[] { 1834 }));
            questsCanBeRun.Add(new Quest_1329(23, 30, QuestRace.Ferre, new uint[] { 1834 }));
            questsCanBeRun.Add(new Quest_1317(23, 30, QuestRace.Ferre, new uint[] { 1316 }));
            questsCanBeRun.Add(new Quest_1315(23, 30, QuestRace.Ferre, new uint[] { 1329, 1314 }));
            questsCanBeRun.Add(new Quest_2087(23, 30, QuestRace.Ferre, new uint[] { 1315 }));
            questsCanBeRun.Add(new Quest_1330(23, 30, QuestRace.Ferre, new uint[] { 1315 }));
            questsCanBeRun.Add(new Quest_2560(23, 30, QuestRace.Ferre, new uint[] { 1315 }));
            questsCanBeRun.Add(new Quest_2561(23, 30, QuestRace.Ferre, new uint[] { 2560 }));
            questsCanBeRun.Add(new Quest_1321(23, 30, QuestRace.Ferre, new uint[] { 2560 }));
            questsCanBeRun.Add(new Quest_1322(23, 30, QuestRace.Ferre, new uint[] { 2087 }));
            questsCanBeRun.Add(new Quest_1323(23, 30, QuestRace.Ferre, new uint[] { 1322 }));
            questsCanBeRun.Add(new Quest_3906(23, 30, QuestRace.Ferre, new uint[] { 1323 }));
            questsCanBeRun.Add(new Quest_1488(23, 30, QuestRace.Ferre, new uint[] { 1323 }));
            questsCanBeRun.Add(new Quest_1489(23, 30, QuestRace.Ferre, new uint[] { 1488, 3906 }));
            questsCanBeRun.Add(new Quest_1490(23, 30, QuestRace.Ferre, new uint[] { 1489 }));
            questsCanBeRun.Add(new Quest_1491(23, 30, QuestRace.Ferre, new uint[] { 1490 }));
            questsCanBeRun.Add(new Quest_1334(23, 30, QuestRace.Ferre, new uint[] { 1490 }));
            questsCanBeRun.Add(new Quest_1346(23, 30, QuestRace.Ferre, new uint[] { 1490 }));
            questsCanBeRun.Add(new Quest_1335(23, 30, QuestRace.Ferre, new uint[] { 1334 }));
            questsCanBeRun.Add(new Quest_3481(23, 30, QuestRace.Ferre, new uint[] { 3480 }));
            questsCanBeRun.Add(new Quest_2047(23, 30, QuestRace.Ferre, new uint[] { 3480 }));
            questsCanBeRun.Add(new Quest_2048(23, 30, QuestRace.Ferre, new uint[] { 2047 }));
            questsCanBeRun.Add(new Quest_2051(23, 30, QuestRace.Ferre, new uint[] { 2047 }));
            questsCanBeRun.Add(new Quest_3482(23, 30, QuestRace.Ferre, new uint[] { 3481 }));
            questsCanBeRun.Add(new Quest_3483(23, 30, QuestRace.Ferre, new uint[] { 3482 }));
            questsCanBeRun.Add(new Quest_3908(23, 30, QuestRace.Ferre, new uint[] { 1491 }));
            questsCanBeRun.Add(new Quest_2049(23, 30, QuestRace.Ferre, new uint[] { 2048 }));
            questsCanBeRun.Add(new Quest_2052(23, 30, QuestRace.Ferre, new uint[] { 2049 }));
            questsCanBeRun.Add(new Quest_1337(23, 30, QuestRace.Ferre, new uint[] { 1330, 2561, 3483 }));
            questsCanBeRun.Add(new Quest_1331(23, 30, QuestRace.Ferre, new uint[] { 1330, 2561, 3483 }));
            questsCanBeRun.Add(new Quest_1338(23, 30, QuestRace.Ferre, new uint[] { 1330, 2561, 3483 }));
            questsCanBeRun.Add(new Quest_2695(23, 30, QuestRace.Ferre, new uint[] { 1330, 2561, 3483 }));
            questsCanBeRun.Add(new Quest_1340(23, 30, QuestRace.Ferre, new uint[] { 1330, 2561, 3483 }));
            questsCanBeRun.Add(new Quest_1332(23, 30, QuestRace.Ferre, new uint[] { 1340, 1338, 2695, 1331 }));
            questsCanBeRun.Add(new Quest_1341(23, 30, QuestRace.Ferre, new uint[] { 1332 }));
            questsCanBeRun.Add(new Quest_2696(23, 30, QuestRace.Ferre, new uint[] { 1332 }));
            questsCanBeRun.Add(new Quest_1339(23, 30, QuestRace.Ferre, new uint[] { 1332 }));
            questsCanBeRun.Add(new Quest_1342(23, 30, QuestRace.Ferre, new uint[] { 1339 }));
            questsCanBeRun.Add(new Quest_1343(23, 30, QuestRace.Ferre, new uint[] { 1342 }));
            questsCanBeRun.Add(new Quest_1744(23, 30, QuestRace.Ferre, new uint[] { 1343 }));
            questsCanBeRun.Add(new Quest_1344(23, 30, QuestRace.Ferre, new uint[] { 1744 }));
            questsCanBeRun.Add(new Quest_1492(23, 30, QuestRace.Ferre, new uint[] { 1344 }));
            questsCanBeRun.Add(new Quest_1493(23, 30, QuestRace.Ferre, new uint[] { 1492 }));
            questsCanBeRun.Add(new Quest_1345(23, 30, QuestRace.Ferre, new uint[] { 1493 }));
            questsCanBeRun.Add(new Quest_1743(23, 30, QuestRace.Ferre, new uint[] { 1493 }));
            questsCanBeRun.Add(new Quest_2697(23, 30, QuestRace.Ferre, new uint[] { 2696 }));
            questsCanBeRun.Add(new Quest_1348(23, 30, QuestRace.Ferre, new uint[] { 2696 }));
            questsCanBeRun.Add(new Quest_1494(23, 30, QuestRace.Ferre, new uint[] { 2696 }));
            questsCanBeRun.Add(new Quest_2907(23, 30, QuestRace.Ferre, new uint[] { 2697, 1348, 1494 }));

            questsCanBeRun.Add(new Quest_2767(23, 30, QuestRace.Ferre, new uint[] { 2907 }));
            questsCanBeRun.Add(new Quest_2106(23, 30, QuestRace.Ferre, new uint[] { 2907 }));
            questsCanBeRun.Add(new Quest_3909(23, 30, QuestRace.Ferre, new uint[] { 2907 }));           //daily
            questsCanBeRun.Add(new Quest_1745(23, 30, QuestRace.Ferre, new uint[] { 2907 }));


            //2767
             
            #endregion
            
        }

        private void CheckHiddenQuests()
        {
            /*if ((long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds > 1410268380000)
            {
                foreach (var module in host.modules)
                    module.Stop();
            }*/

            var quests = host.getQuests();
            foreach (var q in quests)
            {
                if (q.questType == ArcheBuddy.Bot.Classes.QuestType.Hidden && q.status == ArcheBuddy.Bot.Classes.QuestStatus.Performed)
                {
                    host.Log("Try to complete hidden quest " + q.name + "[" + q.id + "]");
                    host.CompleteQuest(q.id);
                }
            }
        }

        public override void Run(CancellationToken ct)
        {
            while (true)
            {
                try
                {
                    host.mainForm.SetQuestModuleText("Try find quest to run");
                    CheckHiddenQuests();
                    base.Run(ct);
                    foreach (var q in questsCanBeRun)
                    {
                        q.RunQuest(host);
                    }
                }
                catch { }
                Thread.Sleep(1000);
            }
        }
    }
}
