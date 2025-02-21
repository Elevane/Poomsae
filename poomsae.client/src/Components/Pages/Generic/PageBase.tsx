import React, { ReactNode } from "react"
import AppLayout from "../../Fragments/Generic/AppLayout"
import HeaderFragment from "../../Fragments/HeaderFragment"
import Footer from "../../Fragments/Generic/Footer"
export interface PageBaseProps {
    children: ReactNode
}
const PageBase: React.FC<PageBaseProps> = ({ children }) => {
    return (
        <AppLayout><HeaderFragment />{children}<Footer /></AppLayout>
    )
}
export default PageBase