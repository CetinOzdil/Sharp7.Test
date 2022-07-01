## Sharp7
To improve socket latency I have modified MsgSocket class to operate SocketAsyncEventArgs and ManualResetEvent.

Modified file is in `Common` project as `Sharp7.cs`.

In tests;
- Snap7 refers to using latest 64-bit `snap7.dll` with `snap7.net.cs`
- Sharp7_v110 refers to using lastest `Sharp7.cs`
- Sharp7 refers to modified `Sharp7.cs`

#### S7-1214 Test (Read 200 bytes 1000 times from markers)
```
Snap7 200 bytes will be read 1000 times...
OK
Snap7 200 bytes 1000 times read in 12441 ms

Sharp7_v110 200 bytes will be read 1000 times...
OK
Sharp7_v110 200 bytes 1000 times read in 12563 ms

Sharp7 200 bytes will be read 1000 times...
OK
Sharp7 200 bytes 1000 times read in 12496 ms
```
Test results from S7-1214 are nothing special.


#### S7-410E Test (Read 200 bytes 1000 times from markers)
```
Snap7 200 bytes will be read 1000 times...
OK
Snap7 200 bytes 1000 times read in 3949 ms

Sharp7_v110 200 bytes will be read 1000 times...
OK
Sharp7_v110 200 bytes 1000 times read in 4894 ms

Sharp7 200 bytes will be read 1000 times...
OK
Sharp7 200 bytes 1000 times read in 3275 ms
```
Test results from S7-410E are showing improvement; 
- %18 faster than Snap7
- %34 faster than Sharp7 v1.1.0

#### Snap7 Server Rich Demo Test (Read 200 bytes 1000 times from DB1)
```
Snap7 200 bytes will be read 1000 times...
OK
Snap7 200 bytes 1000 times read in 1124 ms

Sharp7_v110 200 bytes will be read 1000 times...
OK
Sharp7_v110 200 bytes 1000 times read in 2431 ms

Sharp7 200 bytes will be read 1000 times...
OK
Sharp7 200 bytes 1000 times read in 69 ms
```
Test results from Snap7 Server results are fantastic (15x-35x improvement).

What I interpret from results is gains are becoming bigger with faster responding devices.

All in all results are promising but probably more **stability testing** is needed.

