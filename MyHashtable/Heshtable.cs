using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeshtable
{
    enum Status { empty, filled, deleted } // 0..2

    struct RecipeWithStatus
    {
        public Recipe recipe;
        public Status status;
    }

    class Heshtable
    {

        private int _size;
        private RecipeWithStatus[] _records;
        public Heshtable()
        {
            _size = 10;
            _records = new RecipeWithStatus[10];
        }
        public Heshtable(int size)
        {
            _size = size;
            _records = new RecipeWithStatus[size];
        }
        public int Add(Recipe recipe) //0 - добавил, 1 - не добавил, потому что уже существует такая запись, -1 - не добавил потому что таблица заполнена
        {
            string key1 = recipe._name;
            string key2 = recipe._author;
            string key = key1 + key2;

            int currentAddress = Hesh1(key);
            //int firstHesh = currentAddress;
            int firstDeleted = -1;
            int i = 0;
            for(; (i < _size) && (_records[currentAddress].status != Status.empty); i++)
            {
                if ((_records[currentAddress].status == Status.filled)
                       && (_records[currentAddress].recipe._name == key1)
                       && (_records[currentAddress].recipe._author == key2)) { return 1; }  //если ячейка заполнена и ее ключ такой же как у добавляемой записи
                else if ((_records[currentAddress].status == Status.deleted) && (firstDeleted == -1))
                {
                    firstDeleted = currentAddress;
                }
                currentAddress = Hesh2(currentAddress);
            }
            if (firstDeleted != -1) //если встречался удаленный элемент
            {
                currentAddress = firstDeleted;
            }
            else if (i == _size) { return -1; } //если в таблице нет ячеек с удаленными данными и все заполнены

            _records[currentAddress].recipe = recipe;
            _records[currentAddress].status = Status.filled;
            return 0;
        }
        private int Hesh1(string key)   //Сэджвик, 573 стр., алгоритм Горнера
        {
            int h = 0;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            byte[] keyCode = Encoding.GetEncoding("windows-1251").GetBytes(key);    //беру коды символов строки key из 8-разрядной кодировки "windows - 1251" (расширенный ascii, с русскими буквами)
            int a = 257;    //ближайшее простое число к 2^8
            for (var i = 0; i != key.Length; i++)
            {
                h = (a * h + keyCode[i]) % _size;
            }
            return h;
        }
        private int Hesh2(int hesh)
        {
            return (hesh + 1) % _size;
        }
        public int Del(Recipe recipe)   //0 - удалил, 1 - не удалил
        {
            string key1 = recipe._name;
            string key2 = recipe._author;
            string key = key1 + key2;

            int currentAddress = Hesh1(key);
            //int firstHesh = currentAddress;
            for (int i = 0; (i < _size) && (_records[currentAddress].status != Status.empty); i++)
            {
                if ((_records[currentAddress].status == Status.filled)
                    && (_records[currentAddress].recipe == recipe))
                {
                    _records[currentAddress].status = Status.deleted;
                    return 0;
                }
                currentAddress = Hesh2(currentAddress);
            }
            return 1;
        }
        public int Search(Recipe recipe) //так как таблица статическая, то функция просто возвращает номер записи в таблице (или -1, если такой записи нет)
        {
            string key1 = recipe._name;
            string key2 = recipe._author;
            string key = key1 + key2;

            int currentAddress = Hesh1(key);
            //int firstHesh = currentAddress;
            for (int i = 0; (i < _size) && (_records[currentAddress].status != Status.empty); i++)
            {
                if ((_records[currentAddress].status == Status.filled)
                    && (_records[currentAddress].recipe == recipe))
                {
                    return currentAddress;
                }
                currentAddress = Hesh2(currentAddress);
            }
            return -1;
        }
        public void Print()
        {
            for (int i = 0; i < _size; i++)
            {
                if (_records[i].status == Status.filled)
                {
                    Console.WriteLine("{0}: {1}, {2}, {3:dd/MM/yyyy HH:mm:ss}", i, _records[i].recipe._name, _records[i].recipe._author, _records[i].recipe._date);
                }
                else if ((_records[i].status == Status.empty) || (_records[i].status == Status.deleted))
                {
                    Console.WriteLine("{0}: Empty", i);
                }
            }
        }
        public void PrintWithStatus()
        {
            for (int i = 0; i < _size; i++)
            {
                if (_records[i].status == Status.filled)
                {
                    Console.WriteLine("{0}: {1}, {2}, {3:dd/MM/yyyy HH:mm:ss}, {4}", i, _records[i].recipe._name, _records[i].recipe._author, _records[i].recipe._date, _records[i].status);
                }
                else if ((_records[i].status == Status.empty) || (_records[i].status == Status.deleted))
                {
                    Console.WriteLine("{0}: Empty, {1}", i, _records[i].status);
                }
            }
        }
    }
}
