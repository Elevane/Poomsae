export interface LoginRequest extends IRequest {
    email: string
    password: string
}
export interface RegisterRequest extends LoginRequest {
    ConfirmPassword: string
}

export interface RefreshRequest extends IRequest {
    token: string
}

export type EnumDictionary<T extends string | symbol | number, U> = {
    [K in T]: U;
};

export interface ResetPasswordRequest extends IRequest {
    Oldpassword: string
    NewPassword: string
    ConfirmNewPassword: string
}
export interface DeleteRequest extends IRequest {
    email?: string
    IsAnonimise: boolean
}

export interface IRequest { }