using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_063_D
{
    class Node
    {
        public int NoBuku, ThnTerbit;
        public string JudulBuku, NamaPengarang;
        public Node next;
    }
    class List
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void addNote()
        {
            int NoBuku, ThnTerbit;
            string JudulBuku, NamaPengarang;
            Console.WriteLine("\nMasukan Nomor Buku: ");
            NoBuku = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nMasukan Judul Buku: ");
            JudulBuku = Console.ReadLine();
            Console.WriteLine("\nMasukan Nama Pengarang: ");
            NamaPengarang = Console.ReadLine();
            Console.WriteLine("\nMasukan Tahun Terbit: ");
            ThnTerbit = Convert.ToInt32(Console.ReadLine());

            Node newnode = new Node();
            newnode.NoBuku = NoBuku;
            newnode.JudulBuku = JudulBuku;
            newnode.NamaPengarang = NamaPengarang;
            newnode.ThnTerbit = ThnTerbit;

            //Jika node yg diinput adalah node pertama
            if (START == null || ThnTerbit <= START.ThnTerbit)
            {
                if ((START != null) && (ThnTerbit == START.ThnTerbit))
                {
                    Console.WriteLine("\nTahun terbit tidak diterima karena sudah tersedia");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }
            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (ThnTerbit >= current.ThnTerbit))
            {
                if (ThnTerbit == current.ThnTerbit)
                {
                    Console.WriteLine("Tahun terbit tidak diterima karena sudah tersedia");
                    return;
                }
                previous = current;
                current = previous;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public bool Search(int ThnTerbit, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;
            while ((current != null) && (ThnTerbit != current.ThnTerbit))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return false;
            else
                return true;
        }
        public void BubleSortArray(int ThnTerbit, ref Node previous, ref Node current)
        {
            previous = START;
            current = START.next;
            if ((current != null) && (ThnTerbit != current.ThnTerbit))
            {
                previous = current;
            }
        }
        public void Traverse()
        {
            if (ListEmpty())
                Console.WriteLine("Data Kosong");
            else
            {
                Console.WriteLine("Data yang tersimpan: ");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.ThnTerbit + " "
                        + currentNode.NoBuku + "\n"
                        + currentNode.NamaPengarang + "\n"
                        + currentNode.JudulBuku + "\n");
                Console.WriteLine();
            }
        }
        public bool ListEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("----------MENU---------");
                    Console.WriteLine("1. Masukkan Data Buku");
                    Console.WriteLine("2. Menampilkan Data");
                    Console.WriteLine("3. Mengurutkan Data");
                    Console.WriteLine("4. Mencari Data");
                    Console.WriteLine("5. exit");
                    Console.WriteLine("\nMasukan pilihanmu: ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNote();
                            }
                            break;
                        case '2':
                            {
                                obj.Traverse();
                            }
                            break;
                        case '3':
                            {
                                Console.WriteLine("Saya tidak bisa bubleshort yang linked list");
                            }
                            break;
                        case '4':
                            {
                                if (obj.ListEmpty() == true)
                                {
                                    Console.WriteLine("\nData Kosong");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nMasukkan Tahun Terbit" + "yang akan dicari: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nData tidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData Ditemukan");
                                    Console.WriteLine("--------------------------------------------");
                                    Console.WriteLine("\n Tahun Terbit: " + current.ThnTerbit);
                                    Console.WriteLine("\n No Buku: " + current.NoBuku);
                                    Console.WriteLine("\n Nama Pengarang: " + current.NamaPengarang);
                                    Console.WriteLine("\n Judul Buku: " + current.JudulBuku);
                                    Console.WriteLine("--------------------------------------------");
                                }
                            }
                            break;
                        case '5':
                            {
                                return;
                            }
                        default:
                            {
                                Console.WriteLine("\nPilihan Tidak Tersedia");
                                break;
                            }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("");
                }
            }
        }
    }

    /*JAWABAN 
     * 2. Single Link List
     * 3. PUSH
          POP
     * 4.REAR
         FRONT
     * 5. a) 5
     *    b) 
     *    -> PreOrder
     *    Kunjungan pre-order dilakukan mulai dari akar pohon, dengan urutan:
          1. Cetak isi (data) node yang sedang dikunjungi
          2. Kunjungi kiri node tersebut,
            - Jika kiri bukan kosong (tidak NULL) mulai lagi dari langkah pertama, terapkan untuk kiri ttruktur data tersebut.
            - Jika kiri kosong (NULL), lanjut ke langkah ketiga.
          3. Kunjungi kanan node tersebut,
            - Jika kanan bukan kosong (tidak NULL) mulai lagi dari langkah pertama, terapkan untuk kanan tersebut.
            - Jika kanan kosong (NULL), proses untuk node ini selesai, tuntaskan proses yang sama untuk node yang dikunjungi sebelumnya.
            jai urutannya adalah 
     *    ->Inorder
     *    1. Kunjungi kiri node tersebut,
            - Jika kiri bukan kosong (tidak NULL) mulai lagi dari langkah pertama, terapkan untuk kiri tersebut.
            - Jika kiri kosong (NULL), lanjut ke langkah kedua.
          2. Cetak isi (data) node yang sedang dikunjungi
          3. Kunjungi kanan node tersebut,
            - Jika kanan bukan kosong (tidak NULL) mulai lagi dari langkah pertama, terapkan untuk kanan tersebut.
            - Jika kanan kosong (NULL), proses untuk node ini selesai, tuntaskan proses yang sama untuk node yang dikunjungi sebelumnya
          Jadi, urutannya adalah 1,5,8,10,12,15,20,22,25,28,30,36,38,40,45,48,50*/
}
