import { Layout } from "antd"
import React from "react"

export interface AppLayoutProps {
    children: React.ReactNode
}

const AppLayout: React.FC<AppLayoutProps> = ({ children }) => {
    return (
        <Layout className="app" style={{ minHeight: "100vh" }} >{children}</Layout>
    );
}

export default AppLayout