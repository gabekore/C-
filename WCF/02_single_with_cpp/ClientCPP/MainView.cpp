#include "MainView.h"

using namespace ClientCPP;

[STAThreadAttribute]
int main() {
	Application::Run(gcnew MainView());
	return 0;
}