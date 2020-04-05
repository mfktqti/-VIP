using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Flyweight
{

    /// <summary>
    /// 1、享元模式
    /// 2、单例模式、原型模式、享元模式
    /// 3、享元模式在Net里面的应用
    /// 
    /// 设计模式：追求的是程序设计，追求的是解决问题
    /// 学习套路：
    ///     问题出发--解决问题--总结沉淀--推广应用
    ///     
    /// 享元模式---池化资源管理----C#内在分配探讨
    /// 
    /// 
    /// 
    /// 享元经济：共享一个、多个有成本的物品
    /// 
    /// 
    /// 
    /// 单例：可以保证进程中只有一个对象实例
    /// 要做到单例 ：需要改造类，增加单例逻辑，破坏单例 封装
    /// 
    /// 
    /// 享元模式：只有一个实例，
    /// 对象复用，又不破坏封装
    /// 
    /// 1、统一入加--想控制全局的东西（简单工厂）
    /// 2、添加征用逻辑--静态字典缓存一下
    /// 
    /// 
    /// 享元模式：为了解决对象的复用问题，提供第三方的管理，能完成对象的复用
    /// 1、还可以自行实例化对象，不像单例是强制保证的
    /// 2、享元工厂也可以初始化多个对象--其他地方需要使对象可以找我拿（修改状态）--用完后，可以放回来（还原状态后）
    /// --避免重复的创建和销毁对象，尤其是对非托管资源---池化资源管理
    /// 
    /// 
    ///享元和单例的区别：
    ///享元是借助简单工厂创建对象
    ///单例是靠自己创建对象
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 5; i++)
            {
              Task.Run(() =>
                {
                    var e = FlyweightFactory.CreateBaseWord(WordType.E);
                    var l = FlyweightFactory.CreateBaseWord(WordType.L);
                    var n = FlyweightFactory.CreateBaseWord(WordType.N);
                    Console.WriteLine($"{e.Get()}{l.Get()}{n.Get()}");
                });
                //List<Task> listTask = new List<Task>();
                //listTask.Add(task);
                //Task.WaitAll(listTask.ToArray());
            }

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
