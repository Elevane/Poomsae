

export interface LoginRegisterResponse {
    token: string
}


export interface ApiResult<T> {
    result?: T | null,
    failure?: boolean
    errors?: { [key: string]: string } | null
}

