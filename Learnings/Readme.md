# Round Robin Algrithm (Time Scheduler Algorithm)

- This Algorithm will be used by Time Sharing Processes. (FCFS)
- Each process will be given a 1 Time Quantum and it will switch between the processes.

**Example:** (Take 5ms as a Quantum Time)

- (HEAD)P1(7ms) - P2(3ms) - P3(2ms) - P4(5ms) - (TAIL)P5(7ms) (all the processes will have its own Burst Time)
- First the CPU Scheduler will give the CPU to P1, and P1 will execute for 5ms as it is defined as the Quantum time, and it has remaing 2ms to execute, but the CPU scheduler will switch the current context CPU into the next process P2.
- It will save the current process's state and it will put the remaining process at the Tail of the Queue.
- Then CPU will process the next process in the queue (P2). And so on.
- Once it reaches the end, it will again start the process from Head.
