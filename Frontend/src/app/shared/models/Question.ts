import { Answer } from "./Answer";



export class Question {

    id : string;
    text : string;
    type : string;
    options = [];
    Answers : Answer [] = [];
    answered: boolean;

   //Quizzes : Quiz[];
    //Exams : Exam[];
}
    