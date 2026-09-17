export type User = {
    id: string;
    displayName: string;
    username: string;
    email: string;
    token: string;
    imageUrl?: string;
}

export type LoginCreds = {
    email: string;
    password: string;
}

export type RegisterCreds = {
    email: string;
    displayName: string;
    username: string;
    password: string;
}