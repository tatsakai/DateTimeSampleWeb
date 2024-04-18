using System;

namespace DateTimeSampleWeb.libraries
{
    /// <summary>
    /// このクラスは、App Serviceで稼働するアプリケーション
    /// DateTimeで特定の日時を使用したテストを可能にするために
    /// 環境変数に設定された日時を返すクラスです。
    /// 使い方：
    /// App Seviceのアプリケーション設定にDATETIME_SETTINGSを追加し、
    /// 指定の日時を"yyyy-MM-dd HH:mm:ss"形式で設定してください。
    /// システム時刻を利用する場合は、DATETIME_SETTINGSにNowを設定してください。
    /// ただし、Azureのシステム日付はUTCですので、日本標準時で利用するにはアプリケーション内で
    /// UtcNowメソッドを利用し、TimeSpanを利用し9時間を加算するようにしてください。
    /// このようにしておくことで、ローカルの開発環境でもAzure環境でもTimeZoneを気にすることなく
    /// 利用することが可能です。    
    /// JST取得の方法を別途JstNowメソッドとしてサンプルを記述してありますので、そちらを参考に
    /// してください。
    /// </summary>
    public class DateTimeEX
    {
        public DateTimeEX()
        {
        }
        public static DateTime Now()
        {
            //環境変数を読み出し
            string? env = Environment.GetEnvironmentVariable("DATETIME_SETTINGS");

            try
            {
                //環境変数が存在しない場合か値がNowの場合は現在日時を返す
                if (env == "Now" || env == null)
                {
                    return DateTime.Now;
                }
                else if (env == "UTC")
                {
                    //環境変数が存在し、かつNowでない場合は環境変数の値を返す
                    return DateTime.UtcNow;
                }
                else if (env == "JST")
                {
                    //Azureのシステム日付はUTCですので、9時間加算して返す
                    return (DateTime.UtcNow + TimeSpan.FromHours(9));
                }
                else
                {
                    //環境変数が存在し、かつNowでない場合は環境変数の値を返す
                    return DateTime.Parse(env);
                }
            }
            catch (Exception)
            {
                //環境変数の値が不正な場合は現在日時を返す
                return DateTime.Now;
            }

        }
        public static DateTime UtcNow()
        {
            //環境変数を読み出し
            string? env = Environment.GetEnvironmentVariable("DATETIME_SETTINGS");
            try
            {

                //環境変数が存在しない場合か値がNowの場合は現在日時(UTC)を返す
                if (env == "Now" || env==null)
                {
                    return DateTime.UtcNow;
                }
                else
                {
                    //環境変数が存在し、かつNowでない場合は環境変数の値を返す
                    return DateTime.Parse(env);
                }
            }
            catch (Exception)
            {
                //環境変数の値が不正な場合は現在日時(UTC)を返す
                return DateTime.UtcNow;
            }

        }
        public static DateTime JstNow()
        {
            //環境変数を読み出し
            string? env = Environment.GetEnvironmentVariable("DATETIME_SETTINGS");
            try
            {
                //環境変数が存在しない場合か値がNowの場合は現在日時をJST(日本標準時)で返す
                if (env == "Now" || env == null)
                {
                    //Azureのシステム日付はUTCですので、9時間加算して返す
                    return (DateTime.UtcNow + TimeSpan.FromHours(9));
                }
                else
                {
                    //環境変数が存在し、かつNowでない場合は環境変数の値を返す
                    return DateTime.Parse(env);
                }
            }
            catch (Exception)
            {
                //環境変数の値が不正な場合は現在日時をJST(日本標準時)で返す
                return (DateTime.UtcNow + TimeSpan.FromHours(9));
            }

        }


    }
}
