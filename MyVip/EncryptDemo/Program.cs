using System;
using System.Collections.Generic;

namespace EncryptDemo
{
    /// <summary>
    /// 
    /// 1、MD5 不可逆加密
    /// 2、Des 对象可逆加密
    /// 3、RSA 非对称可逆加密
    /// 4、数字证书 SSL
    /// 
    /// 
    /// MD5：（公开的算法，任何语言实现后的算法都是一样的结果）
    /// 不可逆加密：原谅--加密--密文 ，密方无法解密出原文
    /// 1、相同原文加密的结果是一样的
    /// 2、不同长度的内容加密后 都是32位
    /// 3、原谅差别很小，结果差别很大
    /// 4、不管文件多大，都能产生32位长度的摘要，文件内容有一点改动，结果变化非常大
    /// 
    /// MD5加盐，应对简单密码破解，123456+Jason，  或者MD5再MD5
    /// 
    /// 
    /// MD5的用途：
    ///  1、防篡改：
    ///     源代码管理：SVN--即使电脑断网了，文件有任何改动，都能被发现，--本地保存了一个文件的MD5--文件有更新，MD5就不一样了
    ///     百度网盘：急速上传--扫描文件的MD5---跟已有的文件MD5对比--吻合就表示文件已经存在，不用再上传
    ///  2、密码保存，防止看到明文--应对简单密码破解，123456+Jason，  或者MD5再MD5
    ///  3、防止抵赖，数字签名
    ///  
    /// 
    /// Des 对称可逆加密：加密后能解密回原文，加密Key和解密Key是同一个
    /// 算法都是公开的。密钥是保密的
    /// 
    /// 数据传输 加密解密速度快，密钥的安全
    /// 
    /// 
    /// Rsa 非对称可逆加密，加密后能解密回原文，加密Key和解密Key不是一个，而是一对
    /// 
    /// 算法是公开的，加密Key和解密Key是不能互相推导的，有了密文，没有解密Key，也推导不出原文
    /// 
    /// 
    /// 
    /// 公开加密的Key，保证数据的安全
    /// 
    /// 公开解密的Key，保存消息的来源，消息是谁发出来的
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(MD5Encrypt.Encrypt("1"));
            Console.WriteLine(MD5Encrypt.Encrypt("1"));
            Console.WriteLine(MD5Encrypt.Encrypt("Hello World!"));

            var result =DesEncrypt.Encrypt("Jason");
            Console.WriteLine(result);
            Console.WriteLine(DesEncrypt.Decrypt(result));

            Console.WriteLine("-----Rsa------------");
            KeyValuePair<string,string> keyValuePair =  RsaEncrypt.GetKeyPair();

            result = RsaEncrypt.Encrypt("Jason", keyValuePair.Key);

            Console.WriteLine(RsaEncrypt.Decrypt(result, keyValuePair.Value));


            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
