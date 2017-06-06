% simulink parameters
tSim = 4;
switch_time = 2; % time when control loop is opening (control system)
input = 1; 
P = 2; % reg (open, close, control)
k = 4; % systems gain
T = 3; % systems time constant
initial_state = -1; 

%sim('bareSystem.slx');
%sim('openLoopS.slx');
%sim('closeLoopS.slx');
sim('controlSystem.slx');

f = fopen('C://reference_data.txt', 'w');
fprintf(f, '%12.8f\r\n', simY);
fclose(f);

output_data = 7;
data = importdata('C://data.txt');
t = data(:,1);
y = data(:,output_data);



plot(tout, simY, 'r'); grid on; hold on;
plot(t,y,'b');

sum(abs(y - simY()))