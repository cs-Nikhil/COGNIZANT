export type CourseLevel = 'Beginner' | 'Intermediate' | 'Advanced';

export interface Course {
  id: number;
  code: string;
  title: string;
  description: string;
  category: string;
  level: CourseLevel;
  credits: number;
  durationWeeks: number;
  instructor: string;
  price: number;
  rating: number;
  seats: number;
  featured: boolean;
  tags: string[];
  lessons: string[];
  schedule: string;
}

