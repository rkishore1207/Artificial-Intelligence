# Artificial Intelligence

### Machine Learning

- `Unsupervised` - Human can train them with multiple data, and it will give response based on the patterns without Human intervention.
  > Eg, we are trained them with all versions and prices of IPhone, then it will predict the new version's Price.
- `Supervised` - Human can train them with vast number of data, and it will give response as human asked in a specific way.
  > Eg, We have trained them with data of forests, kids and balls. If we asked about create image with a Kid is playing a ball in Forest. Then it will give one output with that.

### Narrow Artificial Intelligence

- Give only a specified response to user
  > Google Assistant, Siri, Cortona

### Natural Language Processing (NLP)

- Naturally AI will analyze the data, and do the response immediately.
  > Translation, Sentiment Analysis, Question Answer.

## Artificial Intelligence Workloads and Considerations

1. Prediction and Demand Forecasting
   ![Prediction and Demand Forecasting](https://github.com/user-attachments/assets/aea600f6-d6d2-4749-bcaf-eeb9697e0fb2)
2. Anomaly Detection
   ![Anomaly Detection](https://github.com/user-attachments/assets/8ab89ca4-ff5e-42cb-9676-91331d198b36)
3. Computer Vision
   ![Computer](https://github.com/user-attachments/assets/173273a8-8770-4b95-8131-b9495b287e4d)
4. Natural Language Processing

- Regular things such as What time we are closing today? => Model will track the usual work timings, and it will tell us the average opening or close timins. Break timings.

# Agentic AI with Azure

![Quick Picture](https://github.com/user-attachments/assets/eabd0bc9-d97e-4d2c-a837-4f0bbbe954bd)

### LLM (Large Language Model)

- `LLM` is built by **Neural Network Architecture**. Which accepts some input parameter and analyze all the **differenct aspects** of it at the Hidden Layer and produces the output.
- `Foundation Model` is the specific instance or version of the LLM. Eg, GPT-3, GPT-4, Codex.

![LLM](https://github.com/user-attachments/assets/9c9bf807-bff8-49b7-9a28-21bacf1ae043)

- Initially LLMs are respond to the user based on its **trained data set**.
- Then developers have added `tools chain` with the LLM to increase its capabilities. That is **RAG(Retrieval Augmented Generation)** - which allows LLM to generate Tickets or send emails with the help of tools.
- Then AI Agents came into the picture, it will understand the problems in the prompts and **dynamically decide which tool to use** (we are giving full freedom to it) and generate the response for us.

![AI Agent](https://github.com/user-attachments/assets/59304421-5fae-438f-a894-0152bbe7cde4)

## Creation of Azure Open AI Resource

- Just create a Azure Open AI Resource with **S0 price tier**.
- After open it, click the Microsoft Foundry Panel.
- In the panel, we have to create a Deployment Model (Chat Completion Model).
- I have created GPT-4.1-nano - capability is 120K tokens, standard type.
- After deploying it, we have to chat with it, through Chat window.
- First we have to specify the **System Prompt**. Then in our upcoming prompt, our LLM will give the answer based on the System Prompt's context.
- It will have some input Parameters also. `Temperature` (range is 0 - 1), if mininum value has been set, then our LLM will give the more **accurate outputs**, if we set the maximum value, it will give the more **creative outputs**.

## Microsoft Foundry

- There are two types of Foundry projects

1. Standalone Foundry Project
2. AI-Hub based Foundry project

- Hub based project is the old one(Classic approach), Where we can share multiple projects across the team. Applicable for the organization level (Hierarchy based).
  > In portal, Switch button isn't enabled.
- Whereas, Standalone project(new approach) is for the individual one, which is applicable for the simple projects for a specific purpose.
  > In portal, Switch button is enabled.

#### While creating the AI-Hub, we got created AI services which enabled Multi-Model nature for out projects (Not only the Text as the input, we can give Speech, Image or Document), which is including some extra capabilities for out model.

### Azure AI Studio Architecture (Hub based Foundry Project)

![AI Studio Architecture](https://github.com/user-attachments/assets/7780c6a6-7ccd-4d01-8f5b-621082fc9a6e)

1. AI Hub
2. Projects
3. Management Centre - If we create Management center at the Hub level, then all the projects or services created under it, will share it.
4. AI services
5. AI Capabilities - Multimodel in nature
6. Storage - While creating AI Hub, Storage and Keyvault are generating within that resource. Storage account caputes the logs and helps for troubleshooting.
7. Key Vault - Manages the secret keys for Management centre.

## Azure Agentic AI Horizon

![Azure Agentic AIs](https://github.com/user-attachments/assets/97214e47-dfd4-4348-bd94-373fb40dfe72)

- There are two types of Agentic AI present in Azure environment.

1. Declarative Agents - Which have Azure Models and Azure Orchestrating Services
2. Custom Engine Agents - We have built our own Models and own Orchestrating Services.

- `Microsoft Copilot Studio` - Low to No code platform - Declarative Agents - In Align with M365.
- `Microsoft Teams Toolkit` - Pro code platform - Custom Engine Agents - Especially for Teams experience.
- `Azure AI Agentic Services + Semantic Kernel SDKs` - Pro code platform - Custome Engine Agents - In Align with M365.

### Azure Agentic AI Serivces

![Agentic AI](https://github.com/user-attachments/assets/5b02cf42-ea63-4ddb-b5a6-6a0001e0884e)

![Agents Components](https://github.com/user-attachments/assets/f134b9ed-3c37-40c1-8055-471b11188bf0)

![Why Azure AI Agents](https://github.com/user-attachments/assets/44d45cbb-26da-4f86-b522-47d077898e27)

- After creating the AI-Hub and Project inside it. We have to connect our Azure Open AI resource model into it.
- In the Microsoft Foundry Panel, look for Management Center and create a connection to our OpenAI resource.
- On the Agents tab, we can create Agent and each user can have unique thread to the Agent.
- Agent will look all the history in the same thread, and give back response accordingly.

![Chat Completions, Assistant API, Agents](https://github.com/user-attachments/assets/e994ba0c-2d2d-4443-9946-e50bbaa10d60)

### Azure AI Agents with Function Calling

- Actually if the LLM calls multiple tools for data retrieving, then it is an Agent.
- In Function calling, we will write two separate code snippet by Python/C#, one is Mathematical Computation and other one is for Calling APIs through HTTP.

![Function calling](https://github.com/user-attachments/assets/4f767c9f-ccf2-4617-9c4f-3bd86bc84cac)

> How Agent call functions -> Once the user given the input, the Agent only determines which function to call based on the reading from each Custom functions descriptions

### OpenAPI Schema

- To call any Open API endpoints, we have to follow some procedure or pre defined schema.

```C#
  var tools = new List<ChatTool>
  {
      ChatTool.CreateFunctionTool(
          functionName: "GetCurrentWeather",
          functionDescription: "Gets the current weather for a given location",
          functionParameters: BinaryData.FromString("""
          {
              "type": "object",
              "properties": {
                  "location": {
                      "type": "string",
                      "description": "The location to get the weather for (e.g., city name, coordinates)"
                  }
              },
              "required": ["location"]
          }
          """)
      ),
      ChatTool.CreateFunctionTool(
          functionName: "GetUserDetailById",
          functionDescription: "Gets user details by user ID from the system",
          functionParameters: BinaryData.FromString("""
          {
              "type": "object",
              "properties": {
                  "userId": {
                      "type": "integer",
                      "description": "The ID of the user to retrieve details for"
                  }
              },
              "required": ["userId"]
          }
          """)
      )
  };
```

![Open API](https://github.com/user-attachments/assets/ba0ed838-131f-41a7-bc5f-8543178286f5)

## RAG (Retrieval Augmented Generation)

- It is an concept which allows a Gen AI Chat Engine to answer the user queries those information might not be present in the existing database.
- On the flow, Agent will look into the documents and extract the information and answer to the questions.
- For Example, we are having the Travel Agency website. It have lot of different information, texts, PDFs, images, videos, etc...
- Now if we want to bring an Agent on top of it, this RAG will help the Agent to look into all the images or documents based on the user queries and retrive the answer for it.
- Ans also if we don't want to expose the organization's data, we can prefer the RAG.

![RAG](https://github.com/user-attachments/assets/cac84824-414a-4080-a410-519128ad9850)

![RAG Architecture](https://github.com/user-attachments/assets/eb944672-8aa4-4e8e-a43a-6dc252389b4b)

#### Vector Embeddings

- Vector Embeddings helps the Agent to **Organize the informations** in the retrieved documents to a **particular pattern**.
- Actually vector embedding will happen for `User Prompts and the retrieved documents information` and store it as a **Numerical format** in _Vector 3rd space_.
- Then by applying **mathematical techniques** to organize it in a specific pattern.

![Vector Embeddings](https://github.com/user-attachments/assets/dea58946-4b49-4073-98ee-10234fa5a9ca)
