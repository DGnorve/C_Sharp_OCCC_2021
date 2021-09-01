README FOR FINAL_PROJECT_CS2563
THE LOGIN AND PASSWORDS ARE ALL CASE SENSITIVE

LOGIN: Admin
Password: @OCCCFinalProject
Startup Object: Program.cs

<End of useful information\>

This project is incomplete, but i'm turning it in anyway. Every day 
past the 10th is --10%, and i work today (it's 2:24AM at the time of writing)
So it wouldn't be complete even by the 11th.


Personal Details is complete (tabPage1SubForm in VS)
All records can be edited, updated etc.

Medical Details is where the issues arose, Personal Medical Details
i managed to get Display. But modification and updates were completely
foiled, same Queries used in Personal returned false there. 

Probably has something to do with the Key Constraints on them
, but not enough time to figure it out.

I fought my own for an hour and a half tonight before finally getting
Primary_Care_Tbl to cooperate with the FK constraint i added.

The Database you provided i heavily modified, adding a SEC_KEYS table
to store password hashes (because we don't store plain text..)

Along with an Insurance and Emergency Contacts tables to make that much
easier (and faster)

I also corrected multiple spelling errors (i don't think it was
the intention for that col to be NAME_FISRT lel)

And renamed several tables to avoid Ambigious names
(Condition, MED_PROCEDURE)

There's a Patient Class in there, but it's completely unutilized.
There's Classes for Allergies,Immunizations,Conditions, Test_Results,
Procedures, Conditions

These would've been leveraged if i hadn't ran aground on the time crunch
to fill the listViews within tabPage2SubForm with data. 

All in all, iv'e probably done more with SQL than C# this assignment

Well Done~

Here's to whatever grade you decide i've earned, and a fantastic
summer. 

-David G Norvell
 



