import { Question } from "./Question";

export class Quiz {
id: string ;
CourseID : string;
title: string;
questions : Question[] = [];
createdBy : string;
}