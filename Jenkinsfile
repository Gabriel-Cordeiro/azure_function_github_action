pipeline {
  agent any
  stages {
    stage('Build') {
      steps {
        dotnetRestore()
        dotnetTest()
        dotnetPublish(configuration: 'Release')
      }
    }

    stage('Publish') {
      steps {
        azureFunctionAppPublish(deployOnlyIfSuccessful: true, appName: 'publisherNow', resourceGroup: 'TestEventHub', azureCredentialsId: 'AzureCredentials', sourceDirectory: 'azure_function_github_action_main\\src\\Functions\\bin\\Release\\netcoreapp3.1\\publish\\')
      }
    }

  }
}