export interface iUserCredentials {
    email: string
    password: string
}

export interface iUser {
    email: string
    name: string
}

export interface iLoginResponse {
    token: string
}

export interface iRefreshTokenPayload {
    oldToken: string
}