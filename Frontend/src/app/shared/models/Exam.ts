import { Answer } from "./Answer";
import { Question } from "./Question";


export default class Exam {
    ExamID : string;
    Title: string;
    CourseID : string;
    Questions : Question[] = [];
    Answers : Answer[] = [];
    Creatorid : string;
}