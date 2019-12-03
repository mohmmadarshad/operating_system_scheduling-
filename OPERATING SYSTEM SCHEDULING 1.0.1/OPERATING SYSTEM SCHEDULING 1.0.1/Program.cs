using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OPERATING_SYSTEM_SCHEDULING_1._0._1
{

    
    class scheduling
    {
        string cho = "CHOOSE SCHEDULING YOU WANT TO DO";
        public void fcfs()
        {
            int num;
            int i = 0, j = 0;
            decimal avwt = 0, avtat = 0;
            int[] bt = new int[20];
            int[] wt = new int[20];
            int[] tat = new int[20];
            Console.WriteLine("\t\t\tOPERATING SYSTEM SCHDEULING 1.0.1\n");
            Console.WriteLine("Enter total number of processes(maximum 20):");
            num = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter Process Burst Time\n");
            for (i = 0; i < num; i++)
            {
                Console.WriteLine("P[" + (i + 1) + "]:");
                bt[i] = Int32.Parse(Console.ReadLine());
            }

            wt[0] = 0;    //waiting time for first process is 0

            //calculating waiting time
            for (i = 1; i < num; i++)
            {
                wt[i] = 0;
                for (j = 0; j < i; j++)
                    wt[i] += bt[j];
            }

            Console.WriteLine("\nProcess\t\t\tBurst Time\t\tWaiting Time\t\tTurnaround Time");

            //calculating turnaround time
            for (i = 0; i < num; i++)
            {
                tat[i] = bt[i] + wt[i];
                avwt += wt[i];
                avtat += tat[i];
                Console.WriteLine("\nP[" + (i + 1) + "]\t\t\t" + bt[i] + "\t\t\t" + wt[i] + "\t\t\t" + tat[i]);
            }

            avwt /= i;
            avtat /= i;
            Console.WriteLine("\n\nAverage Waiting Time:\t" + avwt);
            Console.WriteLine("\nAverage Turnaround Time:\t" + avtat);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (cho.Length / 2)) + "}", cho));
            Console.ResetColor(); Console.WriteLine("1. First Come, First Server Scheduling\n2. Shortest-Job-First Scheduling\n3. Priority - Scheduling\n4. Round - Robin Scheduling\n5. Multilevel Queue Scheduling\n6. Multilevel Feedback Scheduling\n7. ABOUT DEVELOPER\n\n8. Clear\n9. Exit\n");
            Console.WriteLine("Enter please : -");
        }
        public void preemptivesjfs()
        {
            Console.WriteLine("\t\t\tOPERATING SYSTEM SCHDEULING 1.0.1\n");
            int i, j, n, total = 0, pos, temp;
            int[] bt = new int[20];
            int[] p = new int[20];
            int[] wt = new int[20];
            int[] tat = new int[20];
            float avg_wt, avg_tat;
            Console.WriteLine("Enter number of process:");
            n = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Burst Time:\n");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine("P[" + (i + 1) + "]:");
                bt[i] = Int32.Parse(Console.ReadLine());
                p[i] = i + 1;           //contains process number
            }

            //sorting burst time in ascending order using selection sort
            for (i = 0; i < n; i++)
            {
                pos = i;
                for (j = i + 1; j < n; j++)
                {
                    if (bt[j] < bt[pos])
                        pos = j;
                }

                temp = bt[i];
                bt[i] = bt[pos];
                bt[pos] = temp;

                temp = p[i];
                p[i] = p[pos];
                p[pos] = temp;
            }

            wt[0] = 0;            //waiting time for first process will be zero

            //calculate waiting time
            for (i = 1; i < n; i++)
            {
                wt[i] = 0;
                for (j = 0; j < i; j++)
                    wt[i] += bt[j];

                total += wt[i];
            }

            avg_wt = (float)total / n;      //average waiting time
            total = 0;

            Console.WriteLine("\nProcess\t Burst Time \t\tWaiting Time\tTurnaround Time");
            for (i = 0; i < n; i++)
            {
                tat[i] = bt[i] + wt[i];     //calculate turnaround time
                total += tat[i];
                Console.WriteLine("\nP[" + p[i] + "]\t\t" + bt[i] + "\t\t" + wt[i] + "\t\t\t" + tat[i]);
            }

            avg_tat = (float)total / n;     //average turnaround time
            Console.WriteLine("\n\nAverage Waiting Time=\t" + avg_wt);
            Console.WriteLine("\nAverage Turnaround Time=\t" + avg_tat);

            Console.WriteLine("\n\n\n\t\t\tCHOOSE SCHEDULING YOU WANT TO DO\n");
            Console.WriteLine("\nTHERE ARE TWO TYPE OF Shortest-Job-First Scheduling Algorithm");
            Console.WriteLine("\n1.   PREEMPTIVE SJFS ALGORITHM\n2.   NON - PREEMPTIVE SJFS ALGORITHM\n3.  Exit");
            Console.WriteLine("Enter please : -");
        }
        public void nonpreemtivesjfs()
        {
            Console.WriteLine("\t\t\tOPERATING SYSTEM SCHDEULING 1.0.1\n");
            int[] burst_time = new int[20];
            int[] process = new int[20];
            int[] waiting_time = new int[20];
            int[] turnaround_time = new int[20];
            int[] priority = new int[20];
            int i, j, limit, sum = 0, position, temp;
            float average_wait_time, average_turnaround_time;
            Console.WriteLine("Enter Total Number of Processes:\t");
            limit = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter Burst Time and Priority For " + limit + " Processes\n");
            for (i = 0; i < limit; i++)
            {
                Console.WriteLine("\nProcess[" + (i + 1) + "]\n");
                Console.WriteLine("Process Burst Time:\t");
                burst_time[i] = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Process Priority:\t");
                priority[i] = Int32.Parse(Console.ReadLine());
                process[i] = i + 1;
            }
            for (i = 0; i < limit; i++)
            {
                position = i;
                for (j = i + 1; j < limit; j++)
                {
                    if (priority[j] < priority[position])
                    {
                        position = j;
                    }
                }
                temp = priority[i];
                priority[i] = priority[position];
                priority[position] = temp;
                temp = burst_time[i];
                burst_time[i] = burst_time[position];
                burst_time[position] = temp;
                temp = process[i];
                process[i] = process[position];
                process[position] = temp;
            }
            waiting_time[0] = 0;
            for (i = 1; i < limit; i++)
            {
                waiting_time[i] = 0;
                for (j = 0; j < i; j++)
                {
                    waiting_time[i] = waiting_time[i] + burst_time[j];
                }
                sum = sum + waiting_time[i];
            }
            average_wait_time = sum / limit;
            sum = 0;
            Console.WriteLine("\nProcess ID\t\tBurst Time\t Waiting Time\t Turnaround Time\n");
            for (i = 0; i < limit; i++)
            {
                turnaround_time[i] = burst_time[i] + waiting_time[i];
                sum = sum + turnaround_time[i];
                Console.WriteLine("\nProcess[" + process[i] + "]\t\t" + burst_time[i] + "\t\t" + waiting_time[i] + "\t\t" + turnaround_time[i] + "\n");
            }
            average_turnaround_time = sum / limit;
            Console.WriteLine("\nAverage Waiting Time:\t" + average_wait_time);
            Console.WriteLine("\nAverage Turnaround Time:\t" + average_turnaround_time);

            Console.WriteLine("\n\n\n\t\t\tCHOOSE SCHEDULING YOU WANT TO DO\n");
            Console.WriteLine("\nTHERE ARE TWO TYPE OF Shortest-Job-First Scheduling Algorithm");
            Console.WriteLine("\n1.   PREEMPTIVE SJFS ALGORITHM\n2.   NON - PREEMPTIVE SJFS ALGORITHM\n3.  Exit");
            Console.WriteLine("Enter please : -");
        }
        public void preemptiveprioritysch()
        {
            Console.WriteLine("\t\t\tOPERATING SYSTEM SCHDEULING 1.0.1\n");
            int[] bt = new int[20];
            int[] p = new int[20];
            int[] wt = new int[20];
            int[] tat = new int[20];
            int[] pr = new int[20];
            int i, j, n, total = 0, pos, temp;
            float avg_wt, avg_tat;
            Console.WriteLine("Enter Total Number of Process:");
            n = Int32.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Burst Time and Priority\n");
            for (i = 0; i < n; i++)
            {
                Console.WriteLine("\nP[" + (i + 1) + "]\n");
                Console.WriteLine("Burst Time:");
                bt[i] = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Priority:");
                pr[i] = Int32.Parse(Console.ReadLine());
                p[i] = i + 1;           //contains process number
            }

            //sorting burst time, priority and process number in ascending order using selection sort
            for (i = 0; i < n; i++)
            {
                pos = i;
                for (j = i + 1; j < n; j++)
                {
                    if (pr[j] < pr[pos])
                        pos = j;
                }

                temp = pr[i];
                pr[i] = pr[pos];
                pr[pos] = temp;

                temp = bt[i];
                bt[i] = bt[pos];
                bt[pos] = temp;

                temp = p[i];
                p[i] = p[pos];
                p[pos] = temp;
            }

            wt[0] = 0;    //waiting time for first process is zero

            //calculate waiting time
            for (i = 1; i < n; i++)
            {
                wt[i] = 0;
                for (j = 0; j < i; j++)
                    wt[i] += bt[j];

                total += wt[i];
            }

            avg_wt = total / n;      //average waiting time
            total = 0;

            Console.WriteLine("\nProcess\t    Burst Time    \tWaiting Time\tTurnaround Time");
            for (i = 0; i < n; i++)
            {
                tat[i] = bt[i] + wt[i];     //calculate turnaround time
                total += tat[i];
                Console.WriteLine("\nP[" + p[i] + "]\t\t " + bt[i] + "\t\t" + wt[i] + "\t\t\t" + tat[i]);
            }

            avg_tat = total / n;     //average turnaround time
            Console.WriteLine("\n\nAverage Waiting Time=\t" + avg_wt);
            Console.WriteLine("\nAverage Turnaround Time=\t" + avg_tat);

            Console.WriteLine("\n\n\n\t\t\tCHOOSE SCHEDULING YOU WANT TO DO\n");
            Console.WriteLine("\nTHERE ARE TWO TYPE OF Priority Scheduling Algorithm");
            Console.WriteLine("\n1.   PREEMPTIVE Priority Scheduling ALGORITHM\n2.   NON - PREEMPTIVE Priority - Scheduling ALGORITHM\n3.  Exit");
            Console.WriteLine("Enter please : -");
        }
        public void nonpreemtiveprioritysch()
        {
            Console.WriteLine("\t\t\tOPERATING SYSTEM SCHDEULING 1.0.1\n");
            int[] burst_time = new int[20];
            int[] process = new int[20];
            int[] waiting_time = new int[20];
            int[] turnaround_time = new int[20];
            int[] priority = new int[20];
            int i, j, limit, sum = 0, position, temp;
            float average_wait_time, average_turnaround_time;
            Console.WriteLine("Enter Total Number of Processes:\t");
            limit = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter Burst Time and Priority For " + limit + " Processes\n");
            for (i = 0; i < limit; i++)
            {
                Console.WriteLine("\nProcess[" + (i + 1) + "]\n");
                Console.WriteLine("Process Burst Time:\t");
                burst_time[i] = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Process Priority:\t");
                priority[i] = Int32.Parse(Console.ReadLine());
                process[i] = i + 1;
            }
            for (i = 0; i < limit; i++)
            {
                position = i;
                for (j = i + 1; j < limit; j++)
                {
                    if (priority[j] < priority[position])
                    {
                        position = j;
                    }
                }
                temp = priority[i];
                priority[i] = priority[position];
                priority[position] = temp;
                temp = burst_time[i];
                burst_time[i] = burst_time[position];
                burst_time[position] = temp;
                temp = process[i];
                process[i] = process[position];
                process[position] = temp;
            }
            waiting_time[0] = 0;
            for (i = 1; i < limit; i++)
            {
                waiting_time[i] = 0;
                for (j = 0; j < i; j++)
                {
                    waiting_time[i] = waiting_time[i] + burst_time[j];
                }
                sum = sum + waiting_time[i];
            }
            average_wait_time = sum / limit;
            sum = 0;
            Console.WriteLine("\nProcess ID\t\tBurst Time\t Waiting Time\t Turnaround Time\n");
            for (i = 0; i < limit; i++)
            {
                turnaround_time[i] = burst_time[i] + waiting_time[i];
                sum = sum + turnaround_time[i];
                Console.WriteLine("\nProcess[" + process[i] + "]\t\t" + burst_time[i] + "\t\t" + waiting_time[i] + "\t\t" + turnaround_time[i]);
            }
            average_turnaround_time = sum / limit;
            Console.WriteLine("\nAverage Waiting Time:\t" + average_wait_time);
            Console.WriteLine("\nAverage Turnaround Time:\t" + average_turnaround_time);

            Console.WriteLine("\n\n\n\t\t\tCHOOSE SCHEDULING YOU WANT TO DO\n");
            Console.WriteLine("\nTHERE ARE TWO TYPE OF Priority Scheduling Algorithm");
            Console.WriteLine("\n1.   PREEMPTIVE Priority Scheduling ALGORITHM\n2.   NON - PREEMPTIVE Priority - Scheduling ALGORITHM\n3.  Exit");
            Console.WriteLine("Enter please : -");
        }
        public void roundrobin()
        {
            Console.WriteLine("\t\t\tOPERATING SYSTEM SCHDEULING 1.0.1\n");
            int i, limit, total = 0, x, counter = 0, time_quantum;
            int wait_time = 0, turnaround_time = 0;
            int[] arrival_time = new int[10];
            int[] burst_time = new int[10];
            int[] temp = new int[10];
            float average_wait_time, average_turnaround_time;
            Console.WriteLine("\nEnter Total Number of Processes:\t");
            limit = Int32.Parse(Console.ReadLine());
            x = limit;
            for (i = 0; i < limit; i++)
            {
                Console.WriteLine("\nEnter Details of Process[" + (i + 1) + "]\n");
                Console.WriteLine("Arrival Time:\t");
                arrival_time[i] = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Burst Time:\t");
                burst_time[i] = Int32.Parse(Console.ReadLine());
                temp[i] = burst_time[i];
            }
            Console.WriteLine("\nEnter Time Quantum:\t");
            time_quantum = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nProcess ID\t\tBurst Time\t Turnaround Time\t Waiting Time\n");
            for (total = 0, i = 0; x != 0;)
            {
                if (temp[i] <= time_quantum && temp[i] > 0)
                {
                    total = total + temp[i];
                    temp[i] = 0;
                    counter = 1;
                }
                else if (temp[i] > 0)
                {
                    temp[i] = temp[i] - time_quantum;
                    total = total + time_quantum;
                }
                if (temp[i] == 0 && counter == 1)
                {
                    x--;
                    Console.WriteLine("\nProcess[" + (i + 1) + "]\t\t" + burst_time[i] + "\t\t" + (total - arrival_time[i]) + "\t\t\t" + (total - arrival_time[i] - burst_time[i]));
                    wait_time = wait_time + total - arrival_time[i] - burst_time[i];
                    turnaround_time = turnaround_time + total - arrival_time[i];
                    counter = 0;
                }
                if (i == limit - 1)
                {
                    i = 0;
                }
                else if (arrival_time[i + 1] <= total)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
            average_wait_time = wait_time * 1 / limit;
            average_turnaround_time = turnaround_time * 1 / limit;
            Console.WriteLine("\n\nAverage Waiting Time:\t" + average_wait_time);
            Console.WriteLine("\nAvg Turnaround Time:\t" + average_turnaround_time);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (cho.Length / 2)) + "}", cho));
            Console.ResetColor();
            Console.WriteLine("1. First Come, First Server Scheduling\n2. Shortest-Job-First Scheduling\n3. Priority - Scheduling\n4. Round - Robin Scheduling\n5. Multilevel Queue Scheduling\n6. Multilevel Feedback Scheduling\n7. ABOUT DEVELOPER\n\n8. Clear\n9. Exit\n");

            Console.WriteLine("Enter please : -");

        }
        public void multiqueue()
        {
            Console.WriteLine("\t\t\tOPERATING SYSTEM SCHDEULING 1.0.1\n");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (cho.Length / 2)) + "}", cho));
            Console.WriteLine("1. First Come, First Server Scheduling\n2. Shortest-Job-First Scheduling\n3. Priority - Scheduling\n4. Round - Robin Scheduling\n5. Multilevel Queue Scheduling\n6. Multilevel Feedback Scheduling\n7. ABOUT DEVELOPER\n\n8. Clear\n9. Exit\n");

            Console.WriteLine("Enter please : -");

        }
        //round robin
        struct process_structure
        {
            public
            int process_id, arrival_time, burst_time, priority;
            public
            int q, ready;
        }
        int Queue(int t1)
        {
            if (t1 == 0 || t1 == 1 || t1 == 2 || t1 == 3)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        public void multifeedback()
        {
            Console.WriteLine("\t\t\tOPERATING SYSTEM SCHDEULING 1.0.1\n");
            //int N = 10;
            int limit, count, temp_process, time, j, y;
            process_structure temp;
            Console.WriteLine("Enter Total Number of Processes:\t");
            limit = Int32.Parse(Console.ReadLine());
            process_structure[] process=new process_structure[limit];
            for (count = 0; count < limit; count++)
            {
                Console.WriteLine("\nProcess ID:\t");
                process[count].process_id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Arrival Time:\t");
                process[count].arrival_time = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Burst Time:\t");
                process[count].burst_time = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Process Priority:\t");
                process[count].priority = Int32.Parse(Console.ReadLine());
                temp_process = process[count].priority;
                process[count].q = Queue(temp_process);
                process[count].ready = 0;
            }
            time = process[0].burst_time;
            for (y = 0; y < limit; y++)
            {
                for (count = y; count < limit; count++)
                {
                    if (process[count].arrival_time < time)
                    {
                        process[count].ready = 1;
                    }
                }
                for (count = y; count < limit - 1; count++)
                {
                    for (j = count + 1; j < limit; j++)
                    {
                        if (process[count].ready == 1 && process[j].ready == 1)
                        {
                            if (process[count].q == 2 && process[j].q == 1)
                            {
                                temp = process[count];
                                process[count] = process[j];
                                process[j] = temp;
                            }
                        }
                    }
                }
                for (count = y; count < limit - 1; count++)
                {
                    for (j = count + 1; j < limit; j++)
                    {
                        if (process[count].ready == 1 && process[j].ready == 1)
                        {
                            if (process[count].q == 1 && process[j].q == 1)
                            {
                                if (process[count].burst_time > process[j].burst_time)
                                {
                                    temp = process[count];
                                    process[count] = process[j];
                                    process[j] = temp;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("\nProcess["+ process[y].process_id + "]:\tTime:\t"+time+" To:\t"+ (time + process[y].burst_time) +"\n");
                time = time + process[y].burst_time;
                for (count = y; count < limit; count++)
                {
                    if (process[count].ready == 1)
                    {
                        process[count].ready = 0;
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (cho.Length / 2)) + "}", cho));
            Console.ResetColor();
            Console.WriteLine("1. First Come, First Server Scheduling\n2. Shortest-Job-First Scheduling\n3. Priority - Scheduling\n4. Round - Robin Scheduling\n5. Multilevel Queue Scheduling\n6. Multilevel Feedback Scheduling\n7. ABOUT DEVELOPER\n\n8. Clear\n9. Exit\n");
            Console.WriteLine("Enter please : -");
        }

        
        public void aboutdev()
        {
            Console.WriteLine("\t\t\tOPERATING SYSTEM SCHDEULING 1.0.1\n");
            Console.WriteLine("\t\t\tPlease Wait panel loading.....\n");
            aboutdev aboutdev = new aboutdev();
            Console.Clear();
            System.Windows.Forms.Application.Run(aboutdev);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            string title = "OPERATING SYSTEM SCHDEULING 1.0.1\n";
            string name = "WELCOME TO SCHEDULING SOFTWARE";
            string cho = "CHOOSE SCHEDULING YOU WANT TO DO";
            //Console.WriteLine("\t\t\tOPERATING SYSTEM SCHDEULING 1.0.1\n");
            //Console.WriteLine("\t\t\tWELCOME TO SCHEDULING SOFTWARE\n");
            //Console.WriteLine("\t\t\tCHOOSE SCHEDULING YOU WANT TO DO\n");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (name.Length / 2)) + "}", name));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (cho.Length / 2)) + "}", cho));
            Console.ResetColor();
            Console.WriteLine("1. First Come, First Server Scheduling\n2. Shortest-Job-First Scheduling\n3. Priority - Scheduling\n4. Round - Robin Scheduling\n5. Multilevel Queue Scheduling\n6. Multilevel Feedback Scheduling\n7. ABOUT DEVELOPER\n\n8. Clear\n9. Exit\n");
            Console.WriteLine("Enter please : -");
        }
    }
    
    class Program
    { 
        

        static void Main(string[] args)
        {
            scheduling scheduling = new scheduling();
            Console.WindowWidth = 150;
            Console.WindowHeight = 40;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            string title = "OPERATING SYSTEM SCHDEULING 1.0.1\n";
            string name = "WELCOME TO SCHEDULING SOFTWARE";
            string cho = "CHOOSE SCHEDULING YOU WANT TO DO";
            //Console.WriteLine("\t\t\tOPERATING SYSTEM SCHDEULING 1.0.1\n");
            //Console.WriteLine("\t\t\tWELCOME TO SCHEDULING SOFTWARE\n");
            //Console.WriteLine("\t\t\tCHOOSE SCHEDULING YOU WANT TO DO\n");
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (name.Length / 2)) + "}", name));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (cho.Length / 2)) + "}", cho));
            Console.ResetColor();
            int choose;
            int choosesjfs;
            int progr = 0;
            Console.WriteLine("1. First Come, First Server Scheduling\n2. Shortest-Job-First Scheduling\n3. Priority - Scheduling\n4. Round - Robin Scheduling\n5. Multilevel Queue Scheduling\n6. Multilevel Feedback Scheduling\n7. ABOUT DEVELOPER\n\n8. Clear\n9. Exit\n");
            Console.WriteLine("Enter please : -");
            do
            {
                try
                {

                    do
                    {
                        choose = Int32.Parse(Console.ReadLine());
                        switch (choose)
                        {
                            case 1:
                                scheduling.fcfs();
                                break;

                            case 2:

                                Console.WriteLine("\nTHERE ARE TWO TYPE OF Shortest-Job-First Scheduling Algorithm");
                                Console.WriteLine("\n1.   PREEMPTIVE SJFS ALGORITHM\n2.   NON - PREEMPTIVE SJFS ALGORITHM\n3.  Exit");
                                do
                                {
                                    choosesjfs = Int32.Parse(Console.ReadLine());
                                    switch (choosesjfs)
                                    {
                                        case 1:
                                            scheduling.preemptivesjfs();
                                            break;

                                        case 2:
                                            scheduling.nonpreemtivesjfs();
                                            break;

                                        case 3:
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.BackgroundColor = ConsoleColor.Blue;
                                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (cho.Length / 2)) + "}", cho));
                                            Console.ResetColor();
                                            Console.WriteLine("1. First Come, First Server Scheduling\n2. Shortest-Job-First Scheduling\n3. Priority - Scheduling\n4. Round - Robin Scheduling\n5. Multilevel Queue Scheduling\n6. Multilevel Feedback Scheduling\n7. ABOUT DEVELOPER\n\n8. Clear\n9. Exit\n");
                                            Console.WriteLine("Enter please : -");
                                            break;
                                        default:
                                            Console.WriteLine("PLEASE ENTER THE RIGHT CHOOSE");
                                            break;
                                    }
                                } while (choosesjfs != 3);
                                break;


                            case 3:
                                Console.WriteLine("\nTHERE ARE TWO TYPE OF Priority Scheduling Algorithm");
                                Console.WriteLine("\n1.   PREEMPTIVE Priority Scheduling ALGORITHM\n2.   NON - PREEMPTIVE Priority - Scheduling ALGORITHM\n3.  Exit");
                                int choosespriority;
                                do
                                {

                                    choosespriority = Int32.Parse(Console.ReadLine());
                                    switch (choosespriority)
                                    {
                                        case 1:
                                            scheduling.preemptiveprioritysch();
                                            break;
                                        case 2:
                                            scheduling.nonpreemtiveprioritysch();
                                            break;
                                        case 3:
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.BackgroundColor = ConsoleColor.Blue;
                                            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (cho.Length / 2)) + "}", cho));
                                            Console.ResetColor();
                                            Console.WriteLine("1. First Come, First Server Scheduling\n2. Shortest-Job-First Scheduling\n3. Priority - Scheduling\n4. Round - Robin Scheduling\n5. Multilevel Queue Scheduling\n6. Multilevel Feedback Scheduling\n7. ABOUT DEVELOPER\n\n8. Clear\n9. Exit\n");
                                            Console.WriteLine("Enter please : -");
                                            break;
                                        default:
                                            Console.WriteLine("PLEASE ENTER THE RIGHT CHOOSE");
                                            break;
                                    }
                                } while (choosespriority != 3);
                                break;

                            case 4:
                                scheduling.roundrobin();
                                break;

                            case 5:
                                //scheduling.multiqueue();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nThis panel under develop ");
                                Console.WriteLine("\nSorry");
                                Console.ResetColor();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (cho.Length / 2)) + "}", cho));
                                Console.ResetColor();
                                Console.WriteLine("1. First Come, First Server Scheduling\n2. Shortest-Job-First Scheduling\n3. Priority - Scheduling\n4. Round - Robin Scheduling\n5. Multilevel Queue Scheduling\n6. Multilevel Feedback Scheduling\n7. ABOUT DEVELOPER\n\n8. Clear\n9. Exit\n");
                                Console.WriteLine("Enter please : -");
                                break;

                            case 6:
                                scheduling.multifeedback();
                                break;

                            case 7:
                                scheduling.aboutdev();
                                break;

                            case 8:
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.BackgroundColor = ConsoleColor.Blue;
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (title.Length / 2)) + "}", title));
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (name.Length / 2)) + "}", name));
                                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (cho.Length / 2)) + "}", cho));
                                Console.ResetColor();
                                Console.WriteLine("1. First Come, First Server Scheduling\n2. Shortest-Job-First Scheduling\n3. Priority - Scheduling\n4. Round - Robin Scheduling\n5. Multilevel Queue Scheduling\n6. Multilevel Feedback Scheduling\n7. ABOUT DEVELOPER\n\n8. Clear\n9. Exit\n");
                                Console.WriteLine("Enter please : -");
                                break;
                            case 9:
                                Environment.Exit(0);
                                break;

                            default:
                                Console.WriteLine("PLEASE ENTER THE RIGHT CHOOSE");
                                break;
                        }
                    } while (choose != 9);
                }
                catch
                {

                    Console.WriteLine("PLEASE ENTER THE RIGHT CHOOSE\n\n");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (cho.Length / 2)) + "}", cho));
                    Console.ResetColor();
                    Console.WriteLine("1. First Come, First Server Scheduling\n2. Shortest-Job-First Scheduling\n3. Priority - Scheduling\n4. Round - Robin Scheduling\n5. Multilevel Queue Scheduling\n6. Multilevel Feedback Scheduling\n7. ABOUT DEVELOPER\n\n8. Clear\n9. Exit\n");
                    Console.WriteLine("Enter please : -");
                   // Console.WriteLine("Exception was come\n" + ex);
                }
            } while (progr != 1);
        }
        
    }
}
