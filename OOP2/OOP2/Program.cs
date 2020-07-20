using System;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        void TellStory()
        {
            int a = 3;
            //People pengtao = new People();
            Student pengtao = new Student();
            pengtao.Birth();
            pengtao.Name = "pengtao";
            pengtao.Earn(800);

            Student mazhiyu = new Student();
            mazhiyu.Birth();
            mazhiyu.Name = "mazhiyu";
            mazhiyu.Earn(1000);

            Cafeteria cafe1 = new Cafeteria();

            pengtao.walk();
            mazhiyu.run();

            //fork（分叉）

            while (pengtao.IsHungry() && !pengtao.IsDead())
            {
                int food = cafe1.Charge(10);
                if (food > 0)
                {
                    pengtao.Cost(10);
                    pengtao.Eat(food);
                }
                else
                {
                    cafe1.SupplyFood();
                }
            }

            while (mazhiyu.IsHungry() && !mazhiyu.IsDead())
            {
                int food = cafe1.Charge(10);
                if (food > 0)
                {
                    mazhiyu.Cost(10);
                    mazhiyu.Eat(food);
                }
                else
                {
                    cafe1.SupplyFood();
                }
            }
        }
    }

    class People
    {
        //成员变量:状态
        public String Name;
        bool Gender;
        int Age;
        int HungerLevel;

        //成员方法：功能、动作
        public void Birth()
        {
            Gender = DateTime.Now.Ticks % 2 == 0;
            Age = 0;
            HungerLevel = 100;
        }

        public bool IsHungry()
        {
            return HungerLevel < 60;
        }

        public void Death()
        {
            Age = -1;
            HungerLevel = 0;
        }

        public bool IsDead()
        {
            return HungerLevel < 0;
        }

        public string Say()
        {
            return Say("Hello");
        }

        public string Say(string words)
        {
            if(words == "饿不饿？")
            {
                if (HungerLevel < 60) return "饿了";
                else return "不饿";
            }
            return words;
        }

        public void Eat(int foodSize)
        {
            HungerLevel += foodSize;
        }
        public void walk()
        {
            walk(10);
        }
        public void run()
        {
            walk(100);
        }
        public void walk(int speed)
        {
            HungerLevel = HungerLevel - speed * 1;
        }
    }

    //继承
    class Student : People
    {
        int Money;

        public void Earn(int count)
        {
            Money += count;
        }

        public void Cost(int count)
        {
            Money -= count;
        }
    }

    class Cafeteria
    {
        int FoodHeap;
        int Income;

        public int Charge(int cost)
        {
            int food = cost * 2;
            if(FoodHeap < food)
            {
                return 0;
            }
            else
            {
                Income += cost;
                return food;
            } 
        }

        public void SupplyFood()
        {
            FoodHeap += 100;
        }
    }

}