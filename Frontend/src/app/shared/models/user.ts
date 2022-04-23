
import { Answer } from "./Answer";
import Exam from "./Exam";
import { Quiz } from "./Quiz";
import { Result } from "./Result";

export class user 
{
    Id : string;
    Email : string;
    FirstName : string;
    LastName : string;
    Password : string ;
    ConfirmPassword : string;
    Username : string;
    Results : Result[];
    Answers : Answer[];
    Quizzes : Quiz [];
    Exams : Exam [];
}