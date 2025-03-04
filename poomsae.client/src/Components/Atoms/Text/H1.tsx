import Title from "antd/es/typography/Title"
import { ReactNode } from "react"
interface H1Props {
    children?: ReactNode
}

const H1: React.FC<H1Props> = ({ children }) => {
    return (
        <Title
            style={{ fontFamily: "Nunito, sans-serif", margin: "20px", fontSize: "48px", fontWeight: "bold" }}
            level={1}>
            {children}
        </Title>
    )
}

export default H1