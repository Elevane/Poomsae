export interface SubChildEntity {
    name?: string;
    subChildEntityList?: SubChildEntity[];
    bodyPart?: string;
    from?: string;
    to?: string;
    creator: string | null;
    validated: boolean;
    likes: number;
}

export interface ParentEntity {
    name: string;
    subChildEntityList: SubChildEntity[];
    creator: string | null;
    validated: boolean;
    likes: number;
}