# Online store

This project is a scalable online store application, structured as a set of microservices with each service adhering to clean architecture principles. This approach allows each microservice to be modular, maintainable, and independently deployable, while clean architecture within each service keeps the code organized. 

- **Billing Service**: Handles payment processing, invoicing, and transaction management.
- **Catalog Service**: Manages the product listings, including product details, categories, and availability.
- **Shipment Service**: Manages order shipping, tracking, and delivery status updates.
- **Order Service**: Coordinates the ordering process, from cart management to order confirmation.
- **User Service**: Manages user registration, and profile information. 

- **API Layer**: Defines WebAPI and controllers for client interactions.
- **Application Layer**: Manages use cases and application-specific logic, handling requests and processing responses.
- **Domain Layer**: Contains core business logic and domain entities, independent of external frameworks.
- **Infrastructure Layer**: Manages external dependencies and consume messages from other microservices
- **Persistence Layer**: Handles database interactions and data persistence, separated from the domain logic.
- **Background Job (for specific services)**: Executes asynchronous tasks like sending notifications. 

## Table of Contents
- [Technologies](#technologies)
- [Installation and Setup](#installation-and-setup)
- [Usage](#usage)

## Technologies

The project utilizes the following technologies and libraries:
- Programming languages: `C#`.
- Frameworks: `.NET 8.0`.
- Database: `NpgSQL`.
- Message Broker: `RabbitMQ`
- Containerization: `Docker`

## Installation and Setup

To install and run this project locally, follow these steps:

1. **Clone the repository**:
    ```bash
    git clone https://github.com/ArtemMardash/newStoreOnline
    cd newStoreOnline
    ```

2. **Running with Docker Compose**:

    Ensure Docker and Docker Compose are installed.

    ```bash
    docker-compose up --build
    ```

    This command will start the containers specified in `docker-compose.yml`.

3. **Local Installation** (if not using Docker):

    - Install dependencies: ...
    - Run database migrations (if needed): ...

## Usage

After successfully starting the project:

- The API will be accessible at: `http://localhost:port5432`

### Docker Compose Setup

The following services are defined in the `docker-compose.yml` file:

- **PostgreSQL Database (`postgres.db`)**: Provides the primary database for all services.
- **RabbitMQ (`rabbit`)**: Acts as the message broker for background jobs and asynchronous communication.
- **Billing Service**:
  - `billing.api`: Manages billing API requests.
  - `billing.backgroundjobs`: Executes billing-related background jobs.
- **Catalog Service**:
  - `catalog.api`: Manages catalog API requests.
- **Orders Service**:
  - `orders.api`: Manages order API requests.
  - `orders.backgroundjobs`: Executes order-related background jobs.
- **Shipments Service**:
  - `shipments.backgroundjobs`: Executes shipment-related background jobs.

### Docker Compose Example

To start all services, run the following command:

docker-compose up --build