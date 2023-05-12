from playsound import playsound			#thư viện để play file âm thanh mp3 ngay, ko cần window media trên c#, cài đặt: pip install playsound
import sys
fn = sys.argv[1]	
playsound(fn, True)								#play ra loa
