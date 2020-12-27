using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DS
{
    public class CreateStations
    {

        public static void create50Stations(List<Station> st)
        {
            st.Add(new Station() { CodeStation = 38831, Name = "בי'ס בר לב/בן יהודה", Latitude = 32.183921, Longitude = 34.917806 });
            st.Add(new Station() { CodeStation = 38832, Name = "הרצל/צומת בילו", Latitude = 31.870034, Longitude = 34.819541 });
            st.Add(new Station() { CodeStation = 38833, Name = "הנחשול/הדייגים", Latitude = 31.984553, Longitude = 34.782828 });
            st.Add(new Station() { CodeStation = 38834, Name = "פריד/ששת הימים", Latitude = 31.88855, Longitude = 34.790904 });
            st.Add(new Station() { CodeStation = 38836, Name = "ת. מרכזית לוד/הורדה", Latitude = 31.956392, Longitude = 34.898098 });
            st.Add(new Station() { CodeStation = 38837, Name = "חנה אברך/וולקני", Latitude = 31.892166, Longitude = 34.796071 });
            st.Add(new Station() { CodeStation = 38838, Name = "הרצל/משה שרת", Latitude = 31.857565, Longitude = 34.824106 });
            st.Add(new Station() { CodeStation = 38839, Name = "הבנים/אלי כהן", Latitude = 31.862305, Longitude = 34.821857 });
            st.Add(new Station() { CodeStation = 38840, Name = "ויצמן/הבנים", Latitude = 31.865085, Longitude = 34.822237 });
            st.Add(new Station() { CodeStation = 38841, Name = "האירוס/הכלנית", Latitude = 31.865222, Longitude = 34.818957 });

            st.Add(new Station() { CodeStation = 38842, Name = "הכלנית/הנרקיס", Latitude = 31.867597, Longitude = 34.818392 });
            st.Add(new Station() { CodeStation = 38844, Name = "אלי כהן/לוחמי הגטאות", Latitude = 31.86244, Longitude = 34.827023 });
            st.Add(new Station() { CodeStation = 38845, Name = "שבזי/שבת אחים", Latitude = 31.863501, Longitude = 34.828702 });
            st.Add(new Station() { CodeStation = 38846, Name = "שבזי/ויצמן", Latitude = 31.865348, Longitude = 34.827102 });
            st.Add(new Station() { CodeStation = 38847, Name = "חיים בר לב/שדרות יצחק רבין", Latitude = 31.977409, Longitude = 34.763896 });
            st.Add(new Station() { CodeStation = 38848, Name = "מרכז לבריאות הנפש לב השרון", Latitude = 32.300345, Longitude = 34.912708 });
            st.Add(new Station() { CodeStation = 38849, Name = "מרכז לבריאות הנפש לב השרון", Latitude = 32.301347, Longitude = 34.912602 });
            st.Add(new Station() { CodeStation = 38852, Name = "הולצמן/המדע", Latitude = 31.914255, Longitude = 34.807944 });
            st.Add(new Station() { CodeStation = 38854, Name = "מחנה צריפין/מועדון", Latitude = 31.963668, Longitude = 34.836363 });
            st.Add(new Station() { CodeStation = 38855, Name = "הרצל/גולני", Latitude = 31.856115, Longitude = 34.825249 });

            st.Add(new Station() { CodeStation = 38856, Name = "הרותם/הדגניות", Latitude = 31.874963, Longitude = 34.81249 });
            st.Add(new Station() { CodeStation = 38859, Name = "הערבה", Latitude = 32.300035, Longitude = 34.910842 });
            st.Add(new Station() { CodeStation = 38860, Name = "מבוא הגפן/מורד התאנה", Latitude = 32.305234, Longitude = 34.948647 });
            st.Add(new Station() { CodeStation = 38861, Name = "מבוא הגפן/ההרחבה", Latitude = 32.304022, Longitude = 34.943393 });
            st.Add(new Station() { CodeStation = 38862, Name = "ההרחבה א", Latitude = 32.302957, Longitude = 34.940529 });
            ///////////////
            st.Add(new Station() { CodeStation = 38863, Name = "ההרחבה ב", Latitude = 32.300264, Longitude = 34.939512 });
            st.Add(new Station() { CodeStation = 38864, Name = "ההרחבה/הותיקים", Latitude = 32.298171, Longitude = 34.939512 });
            st.Add(new Station() { CodeStation = 38865, Name = "רשות שדות התעופה/העליה", Latitude = 31.990876, Longitude = 34.8976 });
            st.Add(new Station() { CodeStation = 38866, Name = "כנף/ברוש", Latitude = 31.998767, Longitude = 34.879725 });
            st.Add(new Station() { CodeStation = 38867, Name = "החבורה/דב הוז", Latitude = 31.883019, Longitude = 34.818708 });

            st.Add(new Station() { CodeStation = 38869, Name = "בית הלוי ה", Latitude = 32.349776, Longitude = 34.926837 });
            st.Add(new Station() { CodeStation = 38870, Name = "הראשונים/כביש 5700", Latitude = 32.352953, Longitude = 34.899465 });
            st.Add(new Station() { CodeStation = 38872, Name = "הגאון בן איש חי/צאלון", Latitude = 31.897286, Longitude = 34.775083 });
            st.Add(new Station() { CodeStation = 38873, Name = "עוקשי/לוי אשכול", Latitude = 31.883941, Longitude = 34.807039 });
            st.Add(new Station() { CodeStation = 38875, Name = "מנוחה ונחלה/יהודה גורודיסקי", Latitude = 31.896762, Longitude = 34.816752 });
            st.Add(new Station() { CodeStation = 38876, Name = "גורודסקי/יחיאל פלדי", Latitude = 31.898463, Longitude = 34.823461 });
            st.Add(new Station() { CodeStation = 38877, Name = "דרך מנחם בגין/יעקב חזן", Latitude = 32.076535, Longitude = 34.904907 });
            st.Add(new Station() { CodeStation = 38878, Name = "דרך הפארק/הרב נריה", Latitude = 32.299994, Longitude = 34.878765 });
            st.Add(new Station() { CodeStation = 38879, Name = "התאנה/הגפן", Latitude = 31.865457, Longitude = 34.859437 });
            st.Add(new Station() { CodeStation = 3880, Name = "התאנה/האלון", Latitude = 31.866772, Longitude = 34.864555 });

            st.Add(new Station() { CodeStation = 3881, Name = "דרך הפרחים/יסמין", Latitude = 31.809325, Longitude = 31.809325 });
            st.Add(new Station() { CodeStation = 3883, Name = "יצחק רבין/פנחס ספיר", Latitude = 31.80037, Longitude = 34.778239 });
            st.Add(new Station() { CodeStation = 3884, Name = "מנחם בגין/יצחק רבין", Latitude = 31.799224, Longitude = 34.782985 });
            st.Add(new Station() { CodeStation = 3885, Name = "חיים הרצוג/דולב", Latitude = 31.800334, Longitude = 34.785069 });
            st.Add(new Station() { CodeStation = 3886, Name = "בית ספר גוונים/ארז", Latitude = 31.802319, Longitude = 34.786735 });
            st.Add(new Station() { CodeStation = 3887, Name = "דרך האילנות/אלון", Latitude = 31.804595, Longitude = 34.786623 });
            st.Add(new Station() { CodeStation = 3888, Name = "דרך האילנות/מנחם בגין", Latitude = 31.805041, Longitude = 34.785098 });
            st.Add(new Station() { CodeStation = 3889, Name = "העצמאות/וייצמן", Latitude = 31.816751, Longitude = 34.782252 });
            st.Add(new Station() { CodeStation = 3890, Name = "וייצמן/מרבד הקסמים", Latitude = 31.816579, Longitude = 34.779753 });
            st.Add(new Station() { CodeStation = 3891, Name = "צאלה/אלמוג", Latitude = 31.801182, Longitude = 31.801182 });

        }
    }
}
