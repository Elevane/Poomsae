export interface AppUser {
    username?: string
    isAuthenticated: boolean
    token?: string
}

export interface Dictionnary<T> { [key: string]: T }